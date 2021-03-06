import { Injectable } from '@angular/core';
import { ApplicationLicenseSummary } from '@models/application-license-summary.model';
import { Application } from '@models/application.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { DataService } from './data.service';
import { License } from '@models/license.model';

@Injectable({
  providedIn: 'root'
})
export class LicenseDataService extends DataService {

  apiPath = 'api/licenses/';

  constructor(private http: HttpClient) {
    super();
  }

  getLicenceById(licenseId: string): Observable<License> {
    const url = `${this.apiPath}${licenseId}`;
    return this.http.get<License>(url, { headers: this.headers });
  }

  cancelTransfer(licenceId: string, accountId: string) {
    const url = `${this.apiPath}cancel-transfer`;
    return this.http.post<Application>(url, { licenceId, accountId }, { headers: this.headers });
  }

  initiateTransfer(licenceId: string, accountId: string) {
    const url = `${this.apiPath}initiate-transfer`;
    return this.http.post<Application>(url, {licenceId, accountId}, { headers: this.headers });
  }

  setThirdPartyOperator(licenceId: string, accountId: string) {
    const url = `${this.apiPath}set-third-party-operator`;
    return this.http.post<Application>(url, {licenceId, accountId}, { headers: this.headers });
  }

  // cancel Third Party Operator Application for given licence
  cancelThirdPartyOperator(licenceId: string, accountId: string) {
    const url = `${this.apiPath}cancel-operator-application`;
    return this.http.post<Application>(url, { licenceId, accountId }, { headers: this.headers });
  }

  // terminate Third Party Operator relation for given licence (after approval)
  terminateThirdPartyOperator(licenceId: string, accountId: string) {
    const url = `${this.apiPath}terminate-operator-relationship`;
    return this.http.post<Application>(url, { licenceId, accountId }, { headers: this.headers });
  }

  getAllCurrentLicenses(): Observable<ApplicationLicenseSummary[]> {
    return this.http.get<ApplicationLicenseSummary[]>(this.apiPath + 'current', {
      headers: this.headers
    })
      .pipe(catchError(this.handleError));
  }

  getAllOperatedLicenses(): Observable<ApplicationLicenseSummary[]> {
    return this.http.get<ApplicationLicenseSummary[]>(this.apiPath + 'third-party-operator', {
      headers: this.headers
    })
      .pipe(catchError(this.handleError));
  }

  getAllProposedLicenses(): Observable<ApplicationLicenseSummary[]> {
    return this.http.get<ApplicationLicenseSummary[]>(this.apiPath + 'proposed-owner', {
      headers: this.headers
    })
      .pipe(catchError(this.handleError));
  }

  createApplicationForActionType(licenseId: string, applicationType: string): Observable<Application> {
    const url = `${this.apiPath}${licenseId}/create-action-application/${encodeURIComponent(applicationType)}`;
    return this.http.post<Application>(url, null, { headers: this.headers });
  }

  updateLicenceEstablishment(licenceId: string, licence: ApplicationLicenseSummary): Observable<ApplicationLicenseSummary> {
    return this.http.put<ApplicationLicenseSummary>(this.apiPath + licenceId + '/establishment', licence, { headers: this.headers });
  }

  updateLicenceLDBOrders(licenceId: string, total: number) {
    return this.http.put<License>(this.apiPath + licenceId + '/ldbordertotals', total, { headers: this.headers });
  }

  updateLicenseeRepresentative(licenceId: string, licence: ApplicationLicenseSummary): Observable<ApplicationLicenseSummary> {
    return this.http.put<ApplicationLicenseSummary>(this.apiPath + licenceId + '/representative', licence, { headers: this.headers });
  }
}
