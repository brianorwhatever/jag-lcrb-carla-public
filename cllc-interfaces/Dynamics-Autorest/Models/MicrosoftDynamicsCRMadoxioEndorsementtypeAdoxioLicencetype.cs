// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Lclb.Cllb.Interfaces.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Microsoft.Dynamics.CRM.adoxio_endorsementtype_adoxio_licencetype
    /// </summary>
    public partial class MicrosoftDynamicsCRMadoxioEndorsementtypeAdoxioLicencetype
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMadoxioEndorsementtypeAdoxioLicencetype class.
        /// </summary>
        public MicrosoftDynamicsCRMadoxioEndorsementtypeAdoxioLicencetype()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMadoxioEndorsementtypeAdoxioLicencetype class.
        /// </summary>
        public MicrosoftDynamicsCRMadoxioEndorsementtypeAdoxioLicencetype(string adoxioEndorsementtypeAdoxioLicencetypeid = default(string), string versionnumber = default(string), string adoxioLicencetypeid = default(string), string adoxioEndorsementtypeid = default(string))
        {
            AdoxioEndorsementtypeAdoxioLicencetypeid = adoxioEndorsementtypeAdoxioLicencetypeid;
            Versionnumber = versionnumber;
            AdoxioLicencetypeid = adoxioLicencetypeid;
            AdoxioEndorsementtypeid = adoxioEndorsementtypeid;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_endorsementtype_adoxio_licencetypeid")]
        public string AdoxioEndorsementtypeAdoxioLicencetypeid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "versionnumber")]
        public string Versionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_licencetypeid")]
        public string AdoxioLicencetypeid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_endorsementtypeid")]
        public string AdoxioEndorsementtypeid { get; set; }

    }
}
