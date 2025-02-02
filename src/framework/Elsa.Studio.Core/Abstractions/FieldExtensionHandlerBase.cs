using Elsa.Studio.Contracts;
using Elsa.Studio.Enums;
using Elsa.Studio.Models;
using Microsoft.AspNetCore.Components;

namespace Elsa.Studio.Abstractions;

/// <summary>
/// Provides a base handler for field extensions.
/// </summary>
public abstract class FieldExtensionHandlerBase : IUIFieldExtensionHandler
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public virtual int DisplayOrder { get; set; } = 1;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public virtual FieldExtensionPosition Position { get; set; } = FieldExtensionPosition.Top;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public virtual List<string> LimitToActivities { get; set; } = [];
    
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public abstract bool GetExtensionForInputComponent(string componentName);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public abstract RenderFragment DisplayExtension(DisplayInputEditorContext context);
}