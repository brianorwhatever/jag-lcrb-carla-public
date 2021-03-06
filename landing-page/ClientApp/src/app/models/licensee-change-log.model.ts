import { Account } from './account.model';
import { Application } from './application.model';
import { LegalEntity } from './legal-entity.model';
import { Contact } from './contact.model';
import { LicenseeTreeComponent } from '@shared/components/licensee-tree/licensee-tree.component';

export class LicenseeChangeLog {
  id: string; // guid
  changeType: string;
  isDirectorNew: boolean;
  isDirectorOld: boolean;
  isManagerNew: boolean;
  isManagerOld: boolean;
  isOfficerNew: boolean;
  isOfficerOld: boolean;
  isShareholderNew: boolean;
  isShareholderOld: boolean;
  isTrusteeNew: boolean;
  isTrusteeOld: boolean;
  businessType: string;
  numberofSharesNew: number;
  numberofSharesOld: number;
  totalSharesNew: number;
  totalSharesOld: number;
  emailNew: string;
  emailOld: string;
  firstNameNew: string;
  firstNameOld: string;
  lastNameNew: string;
  lastNameOld: string;
  LicenseeChangelogid: string;
  businessNameNew: string;
  businessNameOld: string;
  nameOld: string;
  dateofBirthNew: Date;
  dateofBirthOld: Date;
  titleNew: string;
  titleOld: string;
  numberOfMembers: number;
  annualMembershipFee: number;

  applicationId: string;
  applicationType: string;
  legalEntityId: string;
  parentLegalEntityId: string;
  parentLinceseeChangeLogId: string;
  parentBusinessAccountId: string;
  businessAccountId: string;
  children: LicenseeChangeLog[];
  parentLinceseeChangeLog: LicenseeChangeLog;
  interestPercentageNew: number;
  interestPercentageOld: number;
  phsLink: string;
  isContactComplete: string;

  isRoot: boolean; // This is only used on the client side
  isIndividual: boolean; // This is only used on the client side
  edit: boolean; // This is only used on the client side
  collapse: boolean; // This is only used on the client side
  saved: boolean; // This is only used on the client side
  fileUploads: any = {}; // This is only used on the client side


  // public get percentageShares(): number {
  //   let percent = 0;
  //   if (this.parentLinceseeChangeLog && this.parentLinceseeChangeLog.totalSharesNew && this.numberofSharesNew) {
  //     percent = this.numberofSharesNew / this.parentLinceseeChangeLog.totalSharesNew * 100;
  //     percent = Math.round(percent * 100) / 100; // round to two decimal places
  //   }
  //   return percent;
  // }


  // public get totalChildShares(): number {
  //   let totalShares = 0;
  //   if (this.children && this.children.length) {
  //     totalShares = this.children.map(v => v.numberofSharesNew || 0).reduce((previous, current) => previous + current);
  //   }
  //   return totalShares;
  // }

  public get keyPersonnelChildren(): LicenseeChangeLog[] {
    const leaders = (this.children || []).filter(item => item.isIndividual && !item.isShareholderNew);
    return leaders;
  }

  public get individualShareholderChildren(): LicenseeChangeLog[] {
    const leaders = (this.children || []).filter(item => item.isIndividual && item.isShareholderNew);
    return leaders;
  }

  public get businessShareholderChildren(): LicenseeChangeLog[] {
    const leaders = (this.children || []).filter(item => !item.isIndividual && item.isShareholderNew);
    return leaders;
  }

  public get keyPersonnelChildrenNoRemoves(): LicenseeChangeLog[] {
    const leaders = (this.children || []).filter(item => {
      item = Object.assign(new LicenseeChangeLog, item);
      return item.isIndividual && !item.isShareholderNew && !item.isRemoveChangeType();
    });
    return leaders;
  }

  public get individualShareholderChildrenNoRemoves(): LicenseeChangeLog[] {
    const leaders = (this.children || []).filter(item => {
      item = Object.assign(new LicenseeChangeLog, item);
      return item.isIndividual && item.isShareholderNew && !item.isRemoveChangeType();
    });
    return leaders;
  }

  public get businessShareholderChildrenNoRemoves(): LicenseeChangeLog[] {
    const leaders = (this.children || []).filter(item => {
      item = Object.assign(new LicenseeChangeLog, item);
      return !item.isIndividual && item.isShareholderNew && !item.isRemoveChangeType();
    });
    return leaders;
  }

  public static GetKeyPersonnelDecendents(changeLog: LicenseeChangeLog): LicenseeChangeLog[] {
    let children = changeLog.children || [];
    let leaders = children.filter(item => item.isIndividual && !item.isShareholderNew && item.changeType !== 'unchanged');
    children.forEach(child => {
      leaders = leaders.concat(LicenseeChangeLog.GetKeyPersonnelDecendents(child));
    });
    return leaders;
  }

  public static HasChanges(changeLog: LicenseeChangeLog): Boolean {
    return this.GetKeyPersonnelDecendents(changeLog).length > 0 || this.GetBusinessShareholderDecendents(changeLog).length > 0 || this.GetIndividualShareholderDecendents(changeLog).length > 0;
  }

  public static GetIndividualShareholderDecendents(changeLog: LicenseeChangeLog): LicenseeChangeLog[] {
    let children = changeLog.children || [];
    let shareholders = children.filter(item => item.isIndividual && item.isShareholderNew && item.changeType !== 'unchanged');
    children.forEach(child => {
      shareholders = shareholders.concat(LicenseeChangeLog.GetIndividualShareholderDecendents(child));
    });
    return shareholders;
  }

  public static GetBusinessShareholderDecendents(changeLog: LicenseeChangeLog): LicenseeChangeLog[] {
    let children = changeLog.children || [];
    let shareholders = children.filter(item => !item.isIndividual && item.isShareholderNew && item.changeType !== 'unchanged');
    children.forEach(child => {
      shareholders = shareholders.concat(LicenseeChangeLog.GetBusinessShareholderDecendents(child));
    });
    return shareholders;
  }

  public static ValidateNonIndividaul(node: LicenseeChangeLog): string[] {
    let validationResult: string[] = [];
    if (node && !node.isIndividual && (node.isShareholderNew || node.isRoot)) {
      if (node.businessType === 'PrivateCorporation' && node.keyPersonnelChildrenNoRemoves.length === 0) {
        validationResult.push(`${node.businessNameNew} needs to have one or more key personnel`);
      }
      if (node.businessType === 'PrivateCorporation'
        && node.businessShareholderChildrenNoRemoves.length === 0
        && node.individualShareholderChildrenNoRemoves.length === 0) {
        validationResult.push(`${node.businessNameNew} needs to have one or more shareholders`);
      }
      if (node.businessType === 'PublicCorporation' && node.keyPersonnelChildrenNoRemoves.length === 0) {
        validationResult.push(`${node.businessNameNew} needs to have one or more key personnel`);
      }
      if (node.businessType === 'Society' && node.keyPersonnelChildrenNoRemoves.length === 0) {
        validationResult.push(`${node.businessNameNew} needs to have one or more  directors & officers`);
      }
      if (node.businessType === 'Partnership'
        && node.keyPersonnelChildrenNoRemoves.length === 0
        && node.businessShareholderChildrenNoRemoves.length === 0
        && node.individualShareholderChildrenNoRemoves.length === 0) {
        validationResult.push(`${node.businessNameNew} needs to have one or more shareholders`);
      }
      if (node.businessType === 'SoleProprietor' && node.keyPersonnelChildrenNoRemoves.length === 0) {
        validationResult.push(`${node.businessNameNew} needs to have a leader`);
      }
    }
    return validationResult;
  }

  // construct file name prefix from name
  public get fileUploadPrefix(): string {
    let prefix = this.nameToFilePrefix();
    return prefix;
  }

  // construct file name prefix from name
  private nameToFilePrefix(): string {
    const MAX_SIZE = 12;
    let prefix = '';
    if (this.isIndividual) {
      prefix = `${this.firstNameNew} ${this.lastNameNew}`;
    } else {
      if ((this.businessNameNew || '').length <= MAX_SIZE) {
        prefix = this.businessNameNew || '';
      } else {
        const length = (this.businessNameNew || '').length;
        // First 8 Characters + Last 4 characters, unless name is less than 12 characters, then show whole name
        prefix = this.businessNameNew.substring(0, 8) + this.businessNameNew.substring(length - 4);
      }
    }
    return prefix;
  }

  /**
   * Create from LegalEntity
   */
  constructor(legalEntity: LegalEntity = null) {
    if (legalEntity) {
      this.legalEntityId = legalEntity.id;
      this.businessAccountId = legalEntity.shareholderAccountId;
      this.businessType = legalEntity.legalentitytype;
      this.isIndividual = legalEntity.isindividual;
      this.parentLegalEntityId = legalEntity.parentLegalEntityId;
      this.changeType = 'unchanged';
      this.isDirectorNew = legalEntity.isDirector;
      this.isDirectorOld = legalEntity.isDirector;
      this.isManagerNew = legalEntity.isSeniorManagement;
      this.isManagerOld = legalEntity.isSeniorManagement;
      this.isOfficerNew = legalEntity.isOfficer;
      this.isOfficerOld = legalEntity.isOfficer;
      this.isShareholderNew = legalEntity.isShareholder;
      this.isShareholderOld = legalEntity.isShareholder;
      this.isTrusteeNew = legalEntity.isTrustee;
      this.isTrusteeOld = legalEntity.isTrustee;
      if (legalEntity.isApplicant) {
        this.businessAccountId = legalEntity.accountId;
      } else {
        this.parentBusinessAccountId = legalEntity.accountId;
        this.businessAccountId = legalEntity.shareholderAccountId;
      }
      this.numberofSharesNew = legalEntity.commonvotingshares;
      this.numberofSharesOld = legalEntity.commonvotingshares;
      this.emailNew = legalEntity.email;
      this.emailOld = legalEntity.email;
      this.firstNameNew = legalEntity.firstname;
      this.firstNameOld = legalEntity.firstname;
      this.lastNameNew = legalEntity.lastname;
      this.lastNameOld = legalEntity.lastname;
      this.businessNameNew = legalEntity.name;
      this.nameOld = legalEntity.name;
      this.dateofBirthNew = legalEntity.dateofbirth;
      this.dateofBirthOld = legalEntity.dateofbirth;
      this.titleNew = legalEntity.jobTitle;
      this.titleOld = legalEntity.jobTitle;
      this.phsLink = legalEntity.phsLink;
    }
  }

  getNewLeadershipPosition(): string {
    let position = '';
    if (this.isDirectorNew) {
      position += 'Director, ';
    }
    if (this.isManagerNew) {
      position += 'Manager, ';
    }
    if (this.isOfficerNew) {
      position += 'Officer, ';
    }
    if (this.isTrusteeNew) {
      position += 'Trustee, ';
    }
    if (this.titleNew) {
      position += `${this.titleNew}, `;
    }
    position = position.substring(0, position.length - 2);
    return position;
  }

  getFileUploadValidationErrors(): string[] {
    let errors = [
      ...this.privateCorpFileErrors(),
      ...this.publicCorpFileErrors(),
      ...this.partnershipFileErrors(),
      ...this.nameChangeFileErrors()
    ];
    return errors;
  }

  private privateCorpFileErrors(): string[] {
    let errors = [];
    if(this.businessType === 'PrivateCorporation'){
      if(this.fileUploads['NOA'] <= 0){
        errors.push(`${this.businessNameNew}: Please upload the Corporation Notice of Articles`);
      }
      if(this.fileUploads['SECREG'] <= 0){
        errors.push(`${this.businessNameNew}: Please upload the Central Securities Register`);
      }
    }
    return errors;
  }

  private publicCorpFileErrors(): string[] {
    let errors = [];
    if(this.businessType === 'PublicCorporation'){
      if(this.fileUploads['NOA'] <= 0){
        errors.push(`${this.businessNameNew}: Please upload the Corporation Notice of Articles`);
      }
    }
    return errors;
  }
  
  private partnershipFileErrors(): string[] {
    let errors = [];
    if(this.businessType === 'Partnership'){
      if(this.fileUploads['NOA'] <= 0){
        errors.push(`${this.businessNameNew}: Please upload the Partnership Agreement`);
      }
    }
    return errors;
  }

  private nameChangeFileErrors(): string[] {
    let errors = [];

    if(this.isNameChangePerformed()){
      if(this.fileUploads['Name Change Documents'] <= 0){
        errors.push(`${this.firstNameNew} ${this.lastNameNew}: Please upload the Name Change Documents`);
      }
    }
    return errors;
  }

  isNameChangePerformed(): boolean {
    let changed = false;
    if (this.isIndividual &&
      (
        this.changeType === LicenseeChangeType.updateLeadership ||
        this.changeType === LicenseeChangeType.updateIndividualShareholder
      )
      &&
      (
        this.firstNameNew !== this.firstNameOld ||
        this.lastNameNew !== this.lastNameOld
      )) {
      changed = true;
    }
    return changed;
  }

  /*
  * Performs a Depth First Traversal and transforms the LegalEntity tree to change objects
  */
  public static processLegalEntityTree(node: LegalEntity): LicenseeChangeLog {
    const newNode = new LicenseeChangeLog(node);
    if (node.children && node.children.length) {
      newNode.children = [];
      node.children.forEach(child => {
        const childNode = this.processLegalEntityTree(child);
        childNode.parentLinceseeChangeLog = newNode;
        newNode.children.push(childNode);
      });
      newNode.children.sort((a, b) => {
        return a.totalSharesNew - b.totalSharesNew;
      });
    }
    return newNode;
  }

  applySavedChangeLogs(currentChangeLogs: LicenseeChangeLog[]) {
    const changesWithLegalEntityId = currentChangeLogs.filter(item => !!item.legalEntityId);
    const changesWithParentLegalEntityId = currentChangeLogs.filter(item => !item.legalEntityId && !!item.parentLegalEntityId);
    const changesWithParentChangeLogId =
      currentChangeLogs.filter(item => !item.legalEntityId && !item.parentLegalEntityId && !!item.parentLinceseeChangeLogId);

    changesWithLegalEntityId.forEach(change => {

      change = Object.assign(new LicenseeChangeLog(), change);
      const node = LicenseeChangeLog.findNodeInTree(this, (node) => node.legalEntityId === change.legalEntityId);
      if (node) {
        if (change.firstNameNew) {
          change.businessNameNew = `${change.firstNameNew} ${change.lastNameNew}`;
        }

        change.isIndividual = change.isIndividualFromChangeType();
        change.children = node.children; //do not overide
        change.isRoot = node.isRoot; //do not overide
        change.parentLinceseeChangeLog = node.parentLinceseeChangeLog; // do not overide
        Object.assign(node, change);
      }
    });

    changesWithParentLegalEntityId.forEach(change => {
      const node = LicenseeChangeLog.findNodeInTree(this, (node) => node.legalEntityId === change.parentLegalEntityId);
      if (node) {
        node.children = node.children || [];
        const newNode = Object.assign(new LicenseeChangeLog(), change);
        if (newNode.firstNameNew) {
          newNode.businessNameNew = `${newNode.firstNameNew} ${newNode.lastNameNew}`;
        }

        newNode.isIndividual = false;
        if (newNode.isIndividualFromChangeType()) {
          newNode.isIndividual = true;
        }
        newNode.parentLinceseeChangeLog = node;
        node.children.push(newNode);
      }
    });

    changesWithParentChangeLogId.forEach(change => {
      const node = LicenseeChangeLog.findNodeInTree(this, (node) => node.id === change.parentLinceseeChangeLogId);
      if (node) {
        node.children = node.children || [];
        const newNode = Object.assign(new LicenseeChangeLog(), change);
        if (newNode.firstNameNew) {
          newNode.businessNameNew = `${newNode.firstNameNew} ${newNode.lastNameNew}`;
        }

        newNode.isIndividual = false;
        if (newNode.isIndividualFromChangeType()) {
          newNode.isIndividual = true;
        }
        newNode.parentLinceseeChangeLog = node;
        node.children.push(newNode);
      }
    });
  }
  /**
    * Finds a node in the tree where the compare predicate returns true
    * @param node 'Node in tree to search from'
    * @param compareFn 'a predicate to search for a node by
    */
  static findNodeInTree(node: LicenseeChangeLog, compareFn: (node: LicenseeChangeLog) => boolean): LicenseeChangeLog {
    let result = null;

    if (compareFn(node)) {
      result = node;
    } else {
      const children = node.children || [];
      for (const child of children) {
        const res = LicenseeChangeLog.findNodeInTree(child, compareFn);
        if (res) {
          result = res;
          break;
        }
      }
    }
    return result;
  }
  /**
    * Finds a nodes in the tree where the compare predicate returns true
    * @param node 'Node in tree to search from'
    * @param compareFn 'a predicate to search for a node by
    */
  static findNodesInTree(node: LicenseeChangeLog, compareFn: (node: LicenseeChangeLog) => boolean): LicenseeChangeLog[] {
    let result = [];

    if (node) {
      if (compareFn(node)) {
        result.push(node);
      }
      const children = node.children || [];
      for (const child of children) {
        const res = LicenseeChangeLog.findNodesInTree(child, compareFn);
        result = result.concat(res);
      }
    }
    return result;
  }

  /**
   * Use the chagetype to check if the licensee is an individual
   * @param changeType
   */
  isIndividualFromChangeType(): boolean {
    const result = this.changeType.toLowerCase().indexOf('individual') !== -1
      || this.changeType.toLowerCase().indexOf('leadership') !== -1;
    return result;
  }

  /**
   * Returns true if the change type is an add. Otherwise it returs false
   * @param node 'A LicenseeChangeLog'
   */
  isAddChangeType(): boolean {
    const result = this.changeType === LicenseeChangeType.addLeadership
      || this.changeType === LicenseeChangeType.addBusinessShareholder
      || this.changeType === LicenseeChangeType.addIndividualShareholder;
    return result;
  }

  /**
   * Returns true if the change type is an update. Otherwise it returs false
   * @param node 'A LicenseeChangeLog'
   */
  isUpdateChangeType(): boolean {
    const result = this.changeType === LicenseeChangeType.updateLeadership
      || this.changeType === LicenseeChangeType.updateBusinessShareholder
      || this.changeType === LicenseeChangeType.updateIndividualShareholder;
    return result;
  }

  /**
   * Returns true if the change type is a delete. Otherwise it returs false
   * @param node 'A LicenseeChangeLog'
   */
  isRemoveChangeType(): boolean {
    const result = this.changeType === LicenseeChangeType.removeLeadership
      || this.changeType === LicenseeChangeType.removeBusinessShareholder
      || this.changeType === LicenseeChangeType.removeIndividualShareholder;
    return result;
  }

}

class DocumentGroup {
  noticeOfArticles: LicenseeChangeLog[] = [];
  centralSecuritiesResgister: LicenseeChangeLog[] = [];
  shareholderList: LicenseeChangeLog[] = [];
  partnershipAgreement: LicenseeChangeLog[] = [];
  trustAgreement: LicenseeChangeLog[] = [];
  societyDocuments: LicenseeChangeLog[] = [];

  get changeLogsPresent(): boolean {
    const allDocsCount = this.noticeOfArticles.length + this.centralSecuritiesResgister.length +
      this.shareholderList.length + this.partnershipAgreement.length;
    return allDocsCount > 0;
  }
}

export enum LicenseeChangeType {
  addLeadership = 'addLeadership',
  updateLeadership = 'updateLeadership',
  removeLeadership = 'removeLeadership',
  addBusinessShareholder = 'addBusinessShareholder',
  updateBusinessShareholder = 'updateBusinessShareholder',
  removeBusinessShareholder = 'removeBusinessShareholder',
  addIndividualShareholder = 'addIndividualShareholder',
  updateIndividualShareholder = 'updateIndividualShareholder',
  removeIndividualShareholder = 'removeIndividualShareholder'
}
