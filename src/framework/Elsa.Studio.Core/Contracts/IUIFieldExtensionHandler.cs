using Elsa.Studio.Enums;
using Elsa.Studio.Models;
using Microsoft.AspNetCore.Components;

namespace Elsa.Studio.Contracts
{
    /// <summary>
    /// Provides a contract for UI field extenstion handlers.
    /// </summary>
    public interface IUIFieldExtensionHandler
    {
        /// <summary>
        /// The order in which the extensions should be displayed.
        /// </summary>
        int DisplayOrder { get; set; }

        /// <summary>
        /// The position to render the extension within the field.
        /// </summary>
        FieldExtensionPosition Position { get; set; }

        /// <summary>
        /// A list of activities this components is limited to render in. Leave empty to remove all render limitions.
        /// </summary>
        List<string> LimitToActivities { get; set; }

        /// <summary>
        /// Returns true if the handler extension the specified.
        /// </summary>
        bool GetExtensionForInputComponent(string componentName);

        /// <summary>
        /// Returns a <see cref="RenderFragment"/> of the added extension.
        /// </summary>
        RenderFragment DisplayExtension(DisplayInputEditorContext context);
    }
}