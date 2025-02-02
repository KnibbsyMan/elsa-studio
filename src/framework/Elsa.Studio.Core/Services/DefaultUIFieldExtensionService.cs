using Elsa.Studio.Contracts;
using Elsa.Studio.Models;

namespace Elsa.Studio.Services;

/// <summary>
/// Provides a default implimentation of UI field extension services.
/// </summary>
/// <param name="handlers"></param>
public class DefaultUIFieldExtensionService(IEnumerable<IUIFieldExtensionHandler> handlers) : IUIFieldExtensionService
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public IUIFieldExtensionHandler? TryGetHandler(string componentName, DisplayInputEditorContext context)
    {
        var activityName = context.ActivityDescriptor.Name;
        var matchingHandler = handlers
            .FirstOrDefault(x => x.GetExtensionForInputComponent(componentName)
                && (!x.LimitToActivities.Any() || x.LimitToActivities.Contains(activityName)));
        return matchingHandler;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public List<IUIFieldExtensionHandler>? TryGetHandlers(string componentName, DisplayInputEditorContext context)
    {
        var activityName = context.ActivityDescriptor.Name;
        var matchingHandlers = handlers
            .Where(x => x.GetExtensionForInputComponent(componentName)
                && (!x.LimitToActivities.Any() || x.LimitToActivities.Contains(activityName)))
            .OrderBy(x => x.DisplayOrder)
            .ToList();
        return matchingHandlers;
    }
}