// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Lclb.Cllb.Interfaces
{
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Feeproduct.
    /// </summary>
    public static partial class FeeproductExtensions
    {
            /// <summary>
            /// Get adoxio_FeeProduct from adoxio_applicationtypefeeschedules
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioApplicationtypefeescheduleid'>
            /// key: adoxio_applicationtypefeescheduleid of
            /// adoxio_applicationtypefeeschedule
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            public static MicrosoftDynamicsCRMproduct Get(this IFeeproduct operations, string adoxioApplicationtypefeescheduleid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.GetAsync(adoxioApplicationtypefeescheduleid, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get adoxio_FeeProduct from adoxio_applicationtypefeeschedules
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioApplicationtypefeescheduleid'>
            /// key: adoxio_applicationtypefeescheduleid of
            /// adoxio_applicationtypefeeschedule
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<MicrosoftDynamicsCRMproduct> GetAsync(this IFeeproduct operations, string adoxioApplicationtypefeescheduleid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(adoxioApplicationtypefeescheduleid, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get adoxio_FeeProduct from adoxio_applicationtypefeeschedules
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioApplicationtypefeescheduleid'>
            /// key: adoxio_applicationtypefeescheduleid of
            /// adoxio_applicationtypefeeschedule
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<MicrosoftDynamicsCRMproduct> GetWithHttpMessages(this IFeeproduct operations, string adoxioApplicationtypefeescheduleid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.GetWithHttpMessagesAsync(adoxioApplicationtypefeescheduleid, select, expand, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

    }
}
