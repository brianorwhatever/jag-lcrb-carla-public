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
    /// Collection of adoxio_relatedparty
    /// </summary>
    /// <remarks>
    /// Microsoft.Dynamics.CRM.adoxio_relatedpartyCollection
    /// </remarks>
    public partial class MicrosoftDynamicsCRMadoxioRelatedpartyCollection
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMadoxioRelatedpartyCollection class.
        /// </summary>
        public MicrosoftDynamicsCRMadoxioRelatedpartyCollection()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMadoxioRelatedpartyCollection class.
        /// </summary>
        public MicrosoftDynamicsCRMadoxioRelatedpartyCollection(IList<MicrosoftDynamicsCRMadoxioRelatedparty> value = default(IList<MicrosoftDynamicsCRMadoxioRelatedparty>))
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
        public IList<MicrosoftDynamicsCRMadoxioRelatedparty> Value { get; set; }

    }
}
