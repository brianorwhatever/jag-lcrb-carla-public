

using Microsoft.Extensions.DependencyInjection;

namespace Gov.Lclb.Cllb.Interfaces
{
    using Microsoft.Rest;
    using Microsoft.Extensions.Configuration;
    using System.Net.Http;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Auto Generated
    /// </summary>
    public partial class DynamicsClient : IDynamicsClient
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public System.Uri NativeBaseUri { get; set; }

        private readonly IConfiguration _configuration;

        [ActivatorUtilitiesConstructor]
        public DynamicsClient(HttpClient httpClient, IConfiguration configuration) 
        {
            Initialize();

            HttpClient = httpClient;

            _configuration = configuration;
            
            string baseUri = _configuration["DYNAMICS_ODATA_URI"]; // Dynamics ODATA endpoint

            if (string.IsNullOrEmpty(baseUri))
            {
                throw new Exception("Configuration setting DYNAMICS_ODATA_URI is blank.");
            }

            ServiceClientCredentials credentials = DynamicsSetupUtil.GetServiceClientCredentials(_configuration);
            BaseUri = new Uri(baseUri);
            Credentials = credentials;

            // set the native client URI.  This is required if you have a reverse proxy or IFD in place and the native URI is different from your access URI.
            if (string.IsNullOrEmpty(_configuration["DYNAMICS_NATIVE_ODATA_URI"]))
            {
                NativeBaseUri = new Uri(_configuration["DYNAMICS_ODATA_URI"]);
            }
            else
            {
                NativeBaseUri = new Uri(_configuration["DYNAMICS_NATIVE_ODATA_URI"]);
            }

            if (Credentials != null)
            {
                Credentials.InitializeServiceClient(this);
            }

            
        }

        public string GetEntityURI(string entityType, string id)
        {
            string result = "";
            if (id != null)
            {
                result = NativeBaseUri + entityType + "(" + id.Trim() + ")";
            }
            return result;
        }

        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="httpOperationException">the source exception</param>
        /// <param name="errorMessage">The error message to present if no entity was created, or null if no error should be shown.</param>
        /// <returns>The ID of a new record, or null of no record was created</returns>
        public string GetCreatedRecord(HttpOperationException httpOperationException, string errorMessage)
        {
            string result = null;
            if (httpOperationException.Response.StatusCode == System.Net.HttpStatusCode.NoContent && httpOperationException.Response.Headers.ContainsKey("OData-EntityId") && httpOperationException.Response.Headers["OData-EntityId"] != null)
            {

                string temp = httpOperationException.Response.Headers["OData-EntityId"].FirstOrDefault();
                int guidStart = temp.LastIndexOf("(");
                int guidEnd = temp.LastIndexOf(")");
                result = temp.Substring(guidStart + 1, guidEnd - (guidStart + 1));

            }
            else
            {
                if (errorMessage != null)
                {
                    Console.WriteLine(errorMessage);
                    Console.WriteLine(httpOperationException.Message);
                    Console.WriteLine(httpOperationException.Request.Content);
                    Console.WriteLine(httpOperationException.Response.Content);
                }
            }
            return result;
        }

        public async Task<MicrosoftDynamicsCRMadoxioApplication> GetApplicationById(Guid id)
        {
            return await GetApplicationById(id.ToString());
        }


        public async Task<MicrosoftDynamicsCRMadoxioApplication> GetApplicationById(string id)
        {
            MicrosoftDynamicsCRMadoxioApplication result;
            try
            {
                // fetch from Dynamics.
                result = await Applications.GetByKeyAsync(id);

                if (result._adoxioLicencetypeValue != null)
                {
                    result.AdoxioLicenceType = GetAdoxioLicencetypeById(Guid.Parse(result._adoxioLicencetypeValue));
                }

                if (result._adoxioApplicantValue != null)
                {
                    result.AdoxioApplicant = await GetAccountByIdAsync(Guid.Parse(result._adoxioApplicantValue));
                }
            }
            catch (HttpOperationException)
            {
                result = null;
            }
            return result;
        }

        public async Task<MicrosoftDynamicsCRMadoxioApplication> GetApplicationByIdWithChildren(string id)
        {
            MicrosoftDynamicsCRMadoxioApplication result;
            try
            {
                string[] expand = { "adoxio_localgovindigenousnationid",
                    "adoxio_application_SharePointDocumentLocations",
                    "adoxio_application_adoxio_tiedhouseconnection_Application",
                    "adoxio_AssignedLicence",
                    "adoxio_ApplicationTypeId",
                    "adoxio_LicenceFeeInvoice",
                    "adoxio_Invoice",
                    "adoxio_localgovindigenousnationid",
                    "adoxio_PoliceJurisdictionId",
                    "adoxio_application_SharePointDocumentLocations"
                };

                // fetch from Dynamics.
                result = await Applications.GetByKeyAsync(id, expand: expand);

                if (result._adoxioLicencetypeValue != null)
                {
                    result.AdoxioLicenceType = GetAdoxioLicencetypeById(Guid.Parse(result._adoxioLicencetypeValue));
                }

                if (result.AdoxioApplicationTypeId != null)
                {
                    var filter = $"_adoxio_applicationtype_value eq { result.AdoxioApplicationTypeId.AdoxioApplicationtypeid}";
                    var typeContents = this.Applicationtypecontents.Get(filter: filter).Value;
                    result.AdoxioApplicationTypeId.AdoxioApplicationtypeAdoxioApplicationtypecontentApplicationType = typeContents;
                }

                if (result._adoxioApplicantValue != null)
                {
                    result.AdoxioApplicant = await GetAccountByIdAsync(Guid.Parse(result._adoxioApplicantValue));
                }

                if (result.AdoxioAssignedLicence != null && result.AdoxioAssignedLicence._adoxioEstablishmentValue != null)
                {
                    result.AdoxioAssignedLicence.AdoxioEstablishment = GetEstablishmentById(Guid.Parse(result.AdoxioAssignedLicence._adoxioEstablishmentValue));
                }
            }
            catch (HttpOperationException)
            {
                result = null;
            }
            return result;
        }

        public async Task<MicrosoftDynamicsCRMadoxioApplication> GetApplicationByIdWithChildren(Guid id)
        {
            return await this.GetApplicationByIdWithChildren(id.ToString());
        }

        public MicrosoftDynamicsCRMadoxioLicencetype GetAdoxioLicencetypeById(Guid id)
        {
            return this.GetAdoxioLicencetypeById(id.ToString());
        }

        public MicrosoftDynamicsCRMadoxioLicencetype GetAdoxioLicencetypeById(string id)
        {
            MicrosoftDynamicsCRMadoxioLicencetype result = null;

            try
            {
                // EXPAND the list of application types for this licence type
                string[] expand = { "adoxio_licencetypes_applicationtypes" };
                result = this.Licencetypes.GetByKey(adoxioLicencetypeid: id, expand: expand);

            }
            catch (HttpOperationException)
            {
                result = null;
            }

            // additional pass to populate the applicationtypes licencetype.
            /*
            if (result.AdoxioLicencetypesApplicationtypes != null)
            {
                foreach (var item in result.AdoxioLicencetypesApplicationtypes)
                {

                    if (item._adoxioLicencetypeidValue != null)
                    {
                        item.AdoxioLicenceTypeId = _dynamicsClient.GetAdoxioLicencetypeById(item._adoxioLicencetypeidValue);
                    }
                }
             }
            */


            return result;
        }

        /// <summary>
        /// Get a Account by their Guid
        /// </summary>
        /// <param name="system"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MicrosoftDynamicsCRMaccount> GetAccountByIdAsync(Guid id)
        {
            MicrosoftDynamicsCRMaccount result;
            try
            {
                string[] expand = { "primarycontactid" };
                // fetch from Dynamics.
                result = await Accounts.GetByKeyAsync(accountid: id.ToString(), expand: expand);
            }
            catch (HttpOperationException)
            {
                result = null;
            }

            return result;
        }

        public MicrosoftDynamicsCRMaccount GetAccountById(Guid id)
        {
            return GetAccountById(id.ToString());
        }

        /// <summary>
        /// Get a Account by their Guid
        /// </summary>
        /// <param name="system"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public MicrosoftDynamicsCRMaccount GetAccountById(string id)
        {
            MicrosoftDynamicsCRMaccount result;
            try
            {
                string[] expand = { "primarycontactid", "Account_SharepointDocumentLocation" };
                // fetch from Dynamics.
                result = Accounts.GetByKey(accountid: id, expand: expand);
            }
            catch (HttpOperationException)
            {
                result = null;
            }

            return result;
        }


        /// <summary>
        /// Get a Account by their Guid
        /// </summary>
        /// <param name="system"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public MicrosoftDynamicsCRMaccount GetAccountByIdWithChildren(string id)
        {
            MicrosoftDynamicsCRMaccount result;
            try
            {
                string[] expand = { "primarycontactid",
                    "Account_SharepointDocumentLocation",
                    "adoxio_account_adoxio_legalentity_Account",
                    "adoxio_account_adoxio_establishment_Licencee",
                    "adoxio_account_adoxio_application_Applicant",
                    "adoxio_licenseechangelog_ParentBusinessAccount",
                    "adoxio_licenseechangelog_BusinessAccount",
                    "adoxio_licenseechangelog_ShareholderBusinessAccount",
                    "adoxio_account_adoxio_licences_Licencee",
                    "contact_customer_accounts",
                    "adoxio_account_tiedhouseconnections"
                };
                // fetch from Dynamics.
                result = Accounts.GetByKey(accountid: id, expand: expand);
            }
            catch (HttpOperationException)
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// Get a Account by their Guid
        /// </summary>
        /// <param name="system"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public MicrosoftDynamicsCRMaccount GetAccountByNameWithEstablishments(string name)
        {
            name = name.Replace("'", "''");
            string[] expand = { "primarycontactid", "adoxio_account_adoxio_establishment_Licencee" };

            MicrosoftDynamicsCRMaccount result;
            try
            {
                string filter = $"name eq '{name}'";
                // fetch from Dynamics.
                result = Accounts.Get(filter: filter).Value.FirstOrDefault();

                if (result != null)
                {
                    result = Accounts.GetByKey(result.Accountid, expand: expand);
                }

            }
            catch (HttpOperationException)
            {
                result = null;
            }


            return result;
        }

        public async Task<MicrosoftDynamicsCRMcontact> GetContactById(string id)
        {
            MicrosoftDynamicsCRMcontact result;
            string[] expand = { "contact_SharePointDocumentLocations" };
            try
            {
                // fetch from Dynamics.
                result = await Contacts.GetByKeyAsync(contactid: id, expand: expand);
            }
            catch (HttpOperationException)
            {
                result = null;
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }

        public async Task<MicrosoftDynamicsCRMcontact> GetContactById(Guid id)
        {
            return await GetContactById(id.ToString());
        }

        public MicrosoftDynamicsCRMadoxioEstablishment GetEstablishmentById(Guid id)
        {
            return GetEstablishmentById(id.ToString());
        }


        public MicrosoftDynamicsCRMadoxioEstablishment GetEstablishmentById(string id)
        {
            MicrosoftDynamicsCRMadoxioEstablishment result = null;
            string[] expand = { "adoxio_Licencee" };
            try
            {
                result = Establishments.GetByKey(adoxioEstablishmentid: id, expand: expand);
            }
            catch (HttpOperationException)
            {
                result = null;
            }

            return result;
        }


        public MicrosoftDynamicsCRMadoxioLocalgovindigenousnation GetLginById(string id)
        {
            MicrosoftDynamicsCRMadoxioLocalgovindigenousnation result = null;

            try
            {
                result = this.Localgovindigenousnations.GetByKey(id);
            }
            catch (HttpOperationException)
            {
                result = null;
            }

            return result;
        }


        public async Task<MicrosoftDynamicsCRMadoxioWorker> GetWorkerById(string id)
        {
            MicrosoftDynamicsCRMadoxioWorker result;
            try
            {
                // fetch from Dynamics.
                result = await Workers.GetByKeyAsync(id);
            }
            catch (HttpOperationException)
            {
                result = null;
            }
            return result;
        }

        public async Task<MicrosoftDynamicsCRMadoxioWorker> GetWorkerById(Guid id)
        {
            return await GetWorkerById(id.ToString());
        }

        public async Task<MicrosoftDynamicsCRMadoxioWorker> GetWorkerByIdWithChildren(string id)
        {

            MicrosoftDynamicsCRMadoxioWorker result;
            try
            {
                // fetch from Dynamics.
                string[] expand = { "adoxio_ContactId", "adoxio_worker_aliases", "adoxio_worker_previousaddresses", "adoxio_worker_SharePointDocumentLocations" };
                result = await this.Workers.GetByKeyAsync(adoxioWorkerid: id, expand: expand);
            }
            catch (HttpOperationException)
            {
                result = null;
            }
            return result;
        }

        public MicrosoftDynamicsCRMadoxioLicences GetLicenceByIdWithChildren(Guid id)
        {
            return GetLicenceByIdWithChildren(id.ToString());
        }

        public MicrosoftDynamicsCRMadoxioLicences GetLicenceByIdWithChildren(string id)
        {
            MicrosoftDynamicsCRMadoxioLicences result;
            try
            {
                // adoxio_Licencee,adoxio_establishment
                // Note that adoxio_Licencee is the Account linked to the licence
                var expand = new List<string> { "adoxio_Licencee", "adoxio_establishment", "adoxio_LicenceType", "adoxio_ThirdPartyOperatorId",
                    "adoxio_adoxio_licences_adoxio_application_AssignedLicence", "adoxio_ProposedOperator", "adoxio_ProposedOwner"
                };
                result = this.Licenceses.GetByKey(adoxioLicencesid: id, expand: expand);
            }
            catch (HttpOperationException)
            {
                // return null if we can't get results.
                result = null;
            }

            if (result != null && result.AdoxioLicencee != null)
            {
                if (!string.IsNullOrEmpty(result.AdoxioLicencee._primarycontactidValue))
                {
                    // get the contact.
                    var runner = this.GetContactById(Guid.Parse(result.AdoxioLicencee._primarycontactidValue));
                    runner.Wait();
                    result.AdoxioLicencee.Primarycontactid = runner.Result;
                }
            }

            return result;
        }

        public MicrosoftDynamicsCRMadoxioEvent GetEventByIdWithChildren(string id)
        {
            MicrosoftDynamicsCRMadoxioEvent result;
            try
            {
                var expand = new List<string> { "adoxio_Account", "adoxio_Licence" };
                result = this.Events.GetByKey(adoxioEventid: id, expand: expand);
            }
            catch (HttpOperationException)
            {
                result = null;
            }

            return result;
        }

        public MicrosoftDynamicsCRMadoxioEvent GetEventById(string id)
        {
            MicrosoftDynamicsCRMadoxioEvent result;
            try
            {
                result = this.Events.GetByKey(adoxioEventid: id);
            }
            catch (HttpOperationException)
            {
                result = null;
            }

            return result;
        }

        public MicrosoftDynamicsCRMadoxioEvent GetEventById(Guid id)
        {
            return GetEventById(id.ToString());
        }

        public MicrosoftDynamicsCRMadoxioEventscheduleCollection GetEventSchedulesByEventId(string id)
        {
            MicrosoftDynamicsCRMadoxioEventscheduleCollection results;
            try
            {
                results = this.Events.GetEventscheduleByEvent(id);
            }
            catch (HttpOperationException)
            {
                results = null;
            }

            return results;
        }

        

   
    }
}
