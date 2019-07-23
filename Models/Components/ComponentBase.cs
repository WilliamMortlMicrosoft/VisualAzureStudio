using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;

namespace VisualAzureStudio.Models.Components
{
    public abstract class ComponentBase
    {
        [Browsable(false)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Description("Name of the Azure resource group that will contain this component.")]
        public string ResourceGroup { get; set; }

        [Description("Name of this component.")]
        public string Name { get; set; }

        [Browsable(false)]
        public Point Location { get; set; }

        [Description("Azure region that will host this component.")]
        public Regions Region { get; set; }

        /// <summary>
        /// Gets the string description of the type. For use by the user interface.
        /// </summary>
        [JsonIgnore]
        [Browsable(false)]
        public abstract string TypeDescription { get; }

        /// <summary>
        /// Gets the index of the image to use for this type. For use by the user interface.
        /// </summary>
        [JsonIgnore]
        [Browsable(false)]
        public abstract int ImageIndex { get; }

        /// <summary>
        /// Gets the background color to use for this type. For use by the user interface.
        /// </summary>
        [JsonIgnore]
        [Browsable(false)]
        public abstract Color BackColor { get; }
    }
}
