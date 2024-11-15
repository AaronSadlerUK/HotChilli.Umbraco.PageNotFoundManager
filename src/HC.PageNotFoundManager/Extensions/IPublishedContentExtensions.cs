using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Services.Navigation;

namespace HC.PageNotFoundManager.Extensions;

internal static class IPublishedContentExtensions
{
    public static bool TryGetParent(this IPublishedContent? node, IDocumentNavigationQueryService documentNavigationQueryService, IPublishedContentCache contentCache, out IPublishedContent? parentNode)
    {
        if(node != null && 
            documentNavigationQueryService.TryGetParentKey(node.Key, out var parentKey) && 
            parentKey != null)
        {
            parentNode = contentCache.GetById(parentKey.Value);
            return true;
        }
        parentNode = null;
        return false;
    }
}
