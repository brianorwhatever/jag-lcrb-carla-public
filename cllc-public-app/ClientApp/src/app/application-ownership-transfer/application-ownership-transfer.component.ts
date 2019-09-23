import { Component, OnInit } from '@angular/core';
import { FormBase } from '@shared/form-base';
import { Application } from '@models/application.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription, Observable, Subject, of, forkJoin } from 'rxjs';
import {
  ApplicationCancellationDialogComponent
} from '@app/applications-and-licences/applications-and-licences.component';
import { ApplicationTypeNames, FormControlState } from '@models/application-type.model';
import { Store } from '@ngrx/store';
import { AppState } from '@app/app-state/models/app-state';
import { PaymentDataService } from '@services/payment-data.service';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Router, ActivatedRoute } from '@angular/router';
import { ApplicationDataService } from '@services/application-data.service';
import { FeatureFlagService } from '@services/feature-flag.service';
import { EstablishmentWatchWordsService } from '@services/establishment-watch-words.service';
import { takeWhile, filter, catchError, mergeMap } from 'rxjs/operators';
import { ApplicationHTMLContent } from '@app/application/application.component';
import { Account } from '@models/account.model';
import * as currentApplicationActions from '@app/app-state/actions/current-application.action';
import { LicenseDataService } from '@services/license-data.service';
import { License } from '@models/license.model';

@Component({
  selector: 'app-application-ownership-transfer',
  templateUrl: './application-ownership-transfer.component.html',
  styleUrls: ['./application-ownership-transfer.component.scss']
})
export class ApplicationOwnershipTransferComponent extends FormBase implements OnInit {
  licence: License;
  form: FormGroup;
  licenceId: string;
  busy: Subscription;
  validationMessages: any[];
  showValidationMessages: boolean;
  htmlContent: ApplicationHTMLContent = <ApplicationHTMLContent>{};
  ApplicationTypeNames = ApplicationTypeNames;
  FormControlState = FormControlState;
  account: Account;
  minDate = new Date();


  constructor(private store: Store<AppState>,
    private paymentDataService: PaymentDataService,
    public snackBar: MatSnackBar,
    public router: Router,
    public applicationDataService: ApplicationDataService,
    private licenseDataService: LicenseDataService,
    public featureFlagService: FeatureFlagService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    public dialog: MatDialog,
    public establishmentWatchWordsService: EstablishmentWatchWordsService) {
    super();
    this.route.paramMap.subscribe(pmap => this.licenceId = pmap.get('licenceId'));
  }

  ngOnInit() {
    this.form = this.fb.group({
      establishmentName: [''],
      accountId: ['', [Validators.required]],
      transferConsent: ['', [this.customRequiredCheckboxValidator()]],
      authorizedToSubmit: ['', [this.customRequiredCheckboxValidator()]],
      signatureAgreement: ['', [this.customRequiredCheckboxValidator()]],
    });

    this.store.select(state => state.currentAccountState.currentAccount)
      .pipe(takeWhile(() => this.componentActive))
      .pipe(filter(account => !!account))
      .subscribe((account) => {
        this.account = account;
      });


    this.busy = this.licenseDataService.getLicenceById(this.licenceId)
      .pipe(takeWhile(() => this.componentActive))
      .subscribe((data: License) => {


        this.licence = data;
        this.form.patchValue({ establishmentName: this.licence.establishmentName });
      },
        () => {
          console.log('Error occured');
        }
      );
  }





  /**
   * Save form data
   * @param showProgress
   */
  save(showProgress: boolean = false): Observable<boolean> {
    return this.licenseDataService.initiateTransfer(this.licence.id, this.form.get('accountId').value)
      .pipe(takeWhile(() => this.componentActive))
      .pipe(catchError(() => {
        this.snackBar.open('Error submitting transfer', 'Fail', { duration: 3500, panelClass: ['red-snackbar'] });
        return of(false);
      }))
      .pipe(mergeMap(() => {
        if (showProgress === true) {
          this.snackBar.open('Transfer has been initiated', 'Success', { duration: 2500, panelClass: ['green-snackbar'] });
        }
        return of(true);
      }));
  }



  updateApplicationInStore() {
    this.applicationDataService.getApplicationById(this.licenceId)
      .pipe(takeWhile(() => this.componentActive))
      .subscribe((data: Application) => {
        this.store.dispatch(new currentApplicationActions.SetCurrentApplicationAction(data));
      }
      );
  }

  /**
  * Initiate licence transfer
  * */
  initiateTransfer() {
    if (!this.isValid()) {
      this.showValidationMessages = true;
    } else {
      this.busy = this.save(true)
        .pipe(takeWhile(() => this.componentActive))
        .subscribe((result: boolean) => {
          if (result) {
            this.router.navigate(['/dashboard']);
          }
        });
    }
  }

  isValid(): boolean {
    // mark controls as touched
    for (const c in this.form.controls) {
      if (typeof (this.form.get(c).markAsTouched) === 'function') {
        this.form.get(c).markAsTouched();
      }
    }
    this.showValidationMessages = false;
    let valid = true;
    this.validationMessages = [];


    if (!this.form.valid) {
      valid = false;
      this.validationMessages.push('Some required fields have not been completed');
    }
    return valid;
  }

  businessTypeIsPartnership(): boolean {
    return this.account &&
      ['GeneralPartnership',
        'LimitedPartnership',
        'LimitedLiabilityPartnership',
        'Partnership'].indexOf(this.account.businessType) !== -1;
  }

  businessTypeIsPrivateCorporation(): boolean {
    return this.account &&
      ['PrivateCorporation',
        'UnlimitedLiabilityCorporation',
        'LimitedLiabilityCorporation'].indexOf(this.account.businessType) !== -1;
  }

  showFormControl(state: string): boolean {
    return [FormControlState.Show.toString(), FormControlState.Reaonly.toString()]
      .indexOf(state) !== -1;
  }

}