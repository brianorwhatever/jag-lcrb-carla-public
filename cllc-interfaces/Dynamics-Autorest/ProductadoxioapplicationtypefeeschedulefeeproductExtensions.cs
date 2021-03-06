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
    /// Extension methods for Productadoxioapplicationtypefeeschedulefeeproduct.
    /// </summary>
    public static partial class ProductadoxioapplicationtypefeeschedulefeeproductExtensions
    {
            /// <summary>
            /// Get adoxio_product_adoxio_applicationtypefeeschedule_FeeProduct from
            /// products
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='productid'>
            /// key: productid of product
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='search'>
            /// </param>
            /// <param name='filter'>
            /// </param>
            /// <param name='count'>
            /// </param>
            /// <param name='orderby'>
            /// Order items by property values
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            public static MicrosoftDynamicsCRMadoxioApplicationtypefeescheduleCollection Get(this IProductadoxioapplicationtypefeeschedulefeeproduct operations, string productid, int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.GetAsync(productid, top, skip, search, filter, count, orderby, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get adoxio_product_adoxio_applicationtypefeeschedule_FeeProduct from
            /// products
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='productid'>
            /// key: productid of product
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='search'>
            /// </param>
            /// <param name='filter'>
            /// </param>
            /// <param name='count'>
            /// </param>
            /// <param name='orderby'>
            /// Order items by property values
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
            public static async Task<MicrosoftDynamicsCRMadoxioApplicationtypefeescheduleCollection> GetAsync(this IProductadoxioapplicationtypefeeschedulefeeproduct operations, string productid, int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(productid, top, skip, search, filter, count, orderby, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get adoxio_product_adoxio_applicationtypefeeschedule_FeeProduct from
            /// products
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='productid'>
            /// key: productid of product
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='search'>
            /// </param>
            /// <param name='filter'>
            /// </param>
            /// <param name='count'>
            /// </param>
            /// <param name='orderby'>
            /// Order items by property values
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
            public static HttpOperationResponse<MicrosoftDynamicsCRMadoxioApplicationtypefeescheduleCollection> GetWithHttpMessages(this IProductadoxioapplicationtypefeeschedulefeeproduct operations, string productid, int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.GetWithHttpMessagesAsync(productid, top, skip, search, filter, count, orderby, select, expand, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get adoxio_product_adoxio_applicationtypefeeschedule_FeeProduct from
            /// products
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='productid'>
            /// key: productid of product
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
            public static MicrosoftDynamicsCRMadoxioApplicationtypefeeschedule FeeProductByKey(this IProductadoxioapplicationtypefeeschedulefeeproduct operations, string productid, string adoxioApplicationtypefeescheduleid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.FeeProductByKeyAsync(productid, adoxioApplicationtypefeescheduleid, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get adoxio_product_adoxio_applicationtypefeeschedule_FeeProduct from
            /// products
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='productid'>
            /// key: productid of product
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
            public static async Task<MicrosoftDynamicsCRMadoxioApplicationtypefeeschedule> FeeProductByKeyAsync(this IProductadoxioapplicationtypefeeschedulefeeproduct operations, string productid, string adoxioApplicationtypefeescheduleid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.FeeProductByKeyWithHttpMessagesAsync(productid, adoxioApplicationtypefeescheduleid, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get adoxio_product_adoxio_applicationtypefeeschedule_FeeProduct from
            /// products
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='productid'>
            /// key: productid of product
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
            public static HttpOperationResponse<MicrosoftDynamicsCRMadoxioApplicationtypefeeschedule> FeeProductByKeyWithHttpMessages(this IProductadoxioapplicationtypefeeschedulefeeproduct operations, string productid, string adoxioApplicationtypefeescheduleid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.FeeProductByKeyWithHttpMessagesAsync(productid, adoxioApplicationtypefeescheduleid, select, expand, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

    }
}
