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
    /// Collection of adoxio_cannabismonthlyreport
    /// </summary>
    /// <remarks>
    /// Microsoft.Dynamics.CRM.adoxio_cannabismonthlyreportCollection
    /// </remarks>
    public partial class MicrosoftDynamicsCRMadoxioCannabismonthlyreportCollection
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMadoxioCannabismonthlyreportCollection class.
        /// </summary>
        public MicrosoftDynamicsCRMadoxioCannabismonthlyreportCollection()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMadoxioCannabismonthlyreportCollection class.
        /// </summary>
        public MicrosoftDynamicsCRMadoxioCannabismonthlyreportCollection(IList<MicrosoftDynamicsCRMadoxioCannabismonthlyreport> value = default(IList<MicrosoftDynamicsCRMadoxioCannabismonthlyreport>))
        {
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<MicrosoftDynamicsCRMadoxioCannabismonthlyreport> Value { get; set; }

    }
}
