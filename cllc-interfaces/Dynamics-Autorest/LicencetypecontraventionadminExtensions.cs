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
    /// Extension methods for Licencetypecontraventionadmin.
    /// </summary>
    public static partial class LicencetypecontraventionadminExtensions
    {
            /// <summary>
            /// Get adoxio_licencetype_contraventionadmin from adoxio_licencetypes
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioLicencetypeid'>
            /// key: adoxio_licencetypeid of adoxio_licencetype
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
            public static MicrosoftDynamicsCRMadoxioContraventionadminCollection Get(this ILicencetypecontraventionadmin operations, string adoxioLicencetypeid, int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.GetAsync(adoxioLicencetypeid, top, skip, search, filter, count, orderby, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get adoxio_licencetype_contraventionadmin from adoxio_licencetypes
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioLicencetypeid'>
            /// key: adoxio_licencetypeid of adoxio_licencetype
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
            public static async Task<MicrosoftDynamicsCRMadoxioContraventionadminCollection> GetAsync(this ILicencetypecontraventionadmin operations, string adoxioLicencetypeid, int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(adoxioLicencetypeid, top, skip, search, filter, count, orderby, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get adoxio_licencetype_contraventionadmin from adoxio_licencetypes
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioLicencetypeid'>
            /// key: adoxio_licencetypeid of adoxio_licencetype
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
            public static HttpOperationResponse<MicrosoftDynamicsCRMadoxioContraventionadminCollection> GetWithHttpMessages(this ILicencetypecontraventionadmin operations, string adoxioLicencetypeid, int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.GetWithHttpMessagesAsync(adoxioLicencetypeid, top, skip, search, filter, count, orderby, select, expand, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get adoxio_licencetype_contraventionadmin from adoxio_licencetypes
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioLicencetypeid'>
            /// key: adoxio_licencetypeid of adoxio_licencetype
            /// </param>
            /// <param name='adoxioContraventionadminid'>
            /// key: adoxio_contraventionadminid of adoxio_contraventionadmin
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            public static MicrosoftDynamicsCRMadoxioContraventionadmin ContraventionadminByKey(this ILicencetypecontraventionadmin operations, string adoxioLicencetypeid, string adoxioContraventionadminid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.ContraventionadminByKeyAsync(adoxioLicencetypeid, adoxioContraventionadminid, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get adoxio_licencetype_contraventionadmin from adoxio_licencetypes
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioLicencetypeid'>
            /// key: adoxio_licencetypeid of adoxio_licencetype
            /// </param>
            /// <param name='adoxioContraventionadminid'>
            /// key: adoxio_contraventionadminid of adoxio_contraventionadmin
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
            public static async Task<MicrosoftDynamicsCRMadoxioContraventionadmin> ContraventionadminByKeyAsync(this ILicencetypecontraventionadmin operations, string adoxioLicencetypeid, string adoxioContraventionadminid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ContraventionadminByKeyWithHttpMessagesAsync(adoxioLicencetypeid, adoxioContraventionadminid, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get adoxio_licencetype_contraventionadmin from adoxio_licencetypes
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioLicencetypeid'>
            /// key: adoxio_licencetypeid of adoxio_licencetype
            /// </param>
            /// <param name='adoxioContraventionadminid'>
            /// key: adoxio_contraventionadminid of adoxio_contraventionadmin
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
            public static HttpOperationResponse<MicrosoftDynamicsCRMadoxioContraventionadmin> ContraventionadminByKeyWithHttpMessages(this ILicencetypecontraventionadmin operations, string adoxioLicencetypeid, string adoxioContraventionadminid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.ContraventionadminByKeyWithHttpMessagesAsync(adoxioLicencetypeid, adoxioContraventionadminid, select, expand, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

    }
}
