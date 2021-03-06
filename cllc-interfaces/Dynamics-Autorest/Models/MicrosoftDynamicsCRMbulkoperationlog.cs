// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Lclb.Cllb.Interfaces.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Microsoft.Dynamics.CRM.bulkoperationlog
    /// </summary>
    public partial class MicrosoftDynamicsCRMbulkoperationlog
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMbulkoperationlog class.
        /// </summary>
        public MicrosoftDynamicsCRMbulkoperationlog()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMbulkoperationlog class.
        /// </summary>
        public MicrosoftDynamicsCRMbulkoperationlog(string additionalinfo = default(string), string _owningteamValue = default(string), string owningbusinessunit = default(string), int? utcconversiontimezonecode = default(int?), System.DateTimeOffset? overriddencreatedon = default(System.DateTimeOffset?), string bulkoperationlogid = default(string), int? errornumber = default(int?), string owninguser = default(string), string _createdobjectidValue = default(string), string _regardingobjectidValue = default(string), string _bulkoperationidValue = default(string), int? importsequencenumber = default(int?), string versionnumber = default(string), string _owneridValue = default(string), string name = default(string), int? timezoneruleversionnumber = default(int?), MicrosoftDynamicsCRMteam owningteam = default(MicrosoftDynamicsCRMteam), IList<MicrosoftDynamicsCRMsyncerror> bulkoperationlogSyncErrors = default(IList<MicrosoftDynamicsCRMsyncerror>), IList<MicrosoftDynamicsCRMteam> bulkoperationlogTeams = default(IList<MicrosoftDynamicsCRMteam>), IList<MicrosoftDynamicsCRMmailboxtrackingfolder> bulkoperationlogMailboxTrackingFolders = default(IList<MicrosoftDynamicsCRMmailboxtrackingfolder>), IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess> bulkoperationlogPrincipalObjectAttributeAccesses = default(IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess>), MicrosoftDynamicsCRMactivitypointer createdobjectidActivitypointer = default(MicrosoftDynamicsCRMactivitypointer), MicrosoftDynamicsCRMcontact createdobjectidContact = default(MicrosoftDynamicsCRMcontact), IList<MicrosoftDynamicsCRMbulkdeletefailure> bulkOperationLogBulkDeleteFailures = default(IList<MicrosoftDynamicsCRMbulkdeletefailure>), MicrosoftDynamicsCRMbulkoperation bulkoperationid = default(MicrosoftDynamicsCRMbulkoperation), MicrosoftDynamicsCRMaccount createdobjectidAccount = default(MicrosoftDynamicsCRMaccount), MicrosoftDynamicsCRMaccount regardingobjectidAccount = default(MicrosoftDynamicsCRMaccount), MicrosoftDynamicsCRMactivitypointer bulkoperationidActivitypointer = default(MicrosoftDynamicsCRMactivitypointer), MicrosoftDynamicsCRMlead createdobjectidLead = default(MicrosoftDynamicsCRMlead), MicrosoftDynamicsCRMopportunity createdobjectidOpportunity = default(MicrosoftDynamicsCRMopportunity), MicrosoftDynamicsCRMcontact regardingobjectidContact = default(MicrosoftDynamicsCRMcontact), IList<MicrosoftDynamicsCRMasyncoperation> bulkOperationLogAsyncOperations = default(IList<MicrosoftDynamicsCRMasyncoperation>), MicrosoftDynamicsCRMlead regardingobjectidLead = default(MicrosoftDynamicsCRMlead))
        {
            Additionalinfo = additionalinfo;
            this._owningteamValue = _owningteamValue;
            Owningbusinessunit = owningbusinessunit;
            Utcconversiontimezonecode = utcconversiontimezonecode;
            Overriddencreatedon = overriddencreatedon;
            Bulkoperationlogid = bulkoperationlogid;
            Errornumber = errornumber;
            Owninguser = owninguser;
            this._createdobjectidValue = _createdobjectidValue;
            this._regardingobjectidValue = _regardingobjectidValue;
            this._bulkoperationidValue = _bulkoperationidValue;
            Importsequencenumber = importsequencenumber;
            Versionnumber = versionnumber;
            this._owneridValue = _owneridValue;
            Name = name;
            Timezoneruleversionnumber = timezoneruleversionnumber;
            Owningteam = owningteam;
            BulkoperationlogSyncErrors = bulkoperationlogSyncErrors;
            BulkoperationlogTeams = bulkoperationlogTeams;
            BulkoperationlogMailboxTrackingFolders = bulkoperationlogMailboxTrackingFolders;
            BulkoperationlogPrincipalObjectAttributeAccesses = bulkoperationlogPrincipalObjectAttributeAccesses;
            CreatedobjectidActivitypointer = createdobjectidActivitypointer;
            CreatedobjectidContact = createdobjectidContact;
            BulkOperationLogBulkDeleteFailures = bulkOperationLogBulkDeleteFailures;
            Bulkoperationid = bulkoperationid;
            CreatedobjectidAccount = createdobjectidAccount;
            RegardingobjectidAccount = regardingobjectidAccount;
            BulkoperationidActivitypointer = bulkoperationidActivitypointer;
            CreatedobjectidLead = createdobjectidLead;
            CreatedobjectidOpportunity = createdobjectidOpportunity;
            RegardingobjectidContact = regardingobjectidContact;
            BulkOperationLogAsyncOperations = bulkOperationLogAsyncOperations;
            RegardingobjectidLead = regardingobjectidLead;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "additionalinfo")]
        public string Additionalinfo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_owningteam_value")]
        public string _owningteamValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owningbusinessunit")]
        public string Owningbusinessunit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "utcconversiontimezonecode")]
        public int? Utcconversiontimezonecode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "overriddencreatedon")]
        public System.DateTimeOffset? Overriddencreatedon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bulkoperationlogid")]
        public string Bulkoperationlogid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "errornumber")]
        public int? Errornumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owninguser")]
        public string Owninguser { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_createdobjectid_value")]
        public string _createdobjectidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_regardingobjectid_value")]
        public string _regardingobjectidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_bulkoperationid_value")]
        public string _bulkoperationidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "importsequencenumber")]
        public int? Importsequencenumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "versionnumber")]
        public string Versionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_ownerid_value")]
        public string _owneridValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timezoneruleversionnumber")]
        public int? Timezoneruleversionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owningteam")]
        public MicrosoftDynamicsCRMteam Owningteam { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bulkoperationlog_SyncErrors")]
        public IList<MicrosoftDynamicsCRMsyncerror> BulkoperationlogSyncErrors { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bulkoperationlog_Teams")]
        public IList<MicrosoftDynamicsCRMteam> BulkoperationlogTeams { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bulkoperationlog_MailboxTrackingFolders")]
        public IList<MicrosoftDynamicsCRMmailboxtrackingfolder> BulkoperationlogMailboxTrackingFolders { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bulkoperationlog_PrincipalObjectAttributeAccesses")]
        public IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess> BulkoperationlogPrincipalObjectAttributeAccesses { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdobjectid_activitypointer")]
        public MicrosoftDynamicsCRMactivitypointer CreatedobjectidActivitypointer { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdobjectid_contact")]
        public MicrosoftDynamicsCRMcontact CreatedobjectidContact { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BulkOperationLog_BulkDeleteFailures")]
        public IList<MicrosoftDynamicsCRMbulkdeletefailure> BulkOperationLogBulkDeleteFailures { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bulkoperationid")]
        public MicrosoftDynamicsCRMbulkoperation Bulkoperationid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdobjectid_account")]
        public MicrosoftDynamicsCRMaccount CreatedobjectidAccount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "regardingobjectid_account")]
        public MicrosoftDynamicsCRMaccount RegardingobjectidAccount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bulkoperationid_activitypointer")]
        public MicrosoftDynamicsCRMactivitypointer BulkoperationidActivitypointer { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdobjectid_lead")]
        public MicrosoftDynamicsCRMlead CreatedobjectidLead { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdobjectid_opportunity")]
        public MicrosoftDynamicsCRMopportunity CreatedobjectidOpportunity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "regardingobjectid_contact")]
        public MicrosoftDynamicsCRMcontact RegardingobjectidContact { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BulkOperationLog_AsyncOperations")]
        public IList<MicrosoftDynamicsCRMasyncoperation> BulkOperationLogAsyncOperations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "regardingobjectid_lead")]
        public MicrosoftDynamicsCRMlead RegardingobjectidLead { get; set; }

    }
}
