// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Lclb.Cllb.Interfaces.GeoCoder.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class JsonResponseCrs
    {
        /// <summary>
        /// Initializes a new instance of the JsonResponseCrs class.
        /// </summary>
        public JsonResponseCrs()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the JsonResponseCrs class.
        /// </summary>
        public JsonResponseCrs(string type = default(string), JsonResponseCrsProperties properties = default(JsonResponseCrsProperties))
        {
            Type = type;
            Properties = properties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public JsonResponseCrsProperties Properties { get; set; }

    }
}
