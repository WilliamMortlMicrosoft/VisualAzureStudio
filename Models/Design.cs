using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using VisualAzureStudio.Models.Components;
using VisualAzureStudio.Models.Connections;

namespace VisualAzureStudio.Models
{
    public class Design
    {
        [Browsable(false)]
        [JsonIgnore]
        public bool IsDirty { get; set; } = false;

        [Browsable(false)]
        public List<ComponentBase> Components { get; set; } = new List<ComponentBase>();

        [Browsable(false)]
        public List<ConnectionBase> Connections { get; set; } = new List<ConnectionBase>();

        /// <summary>
        /// Gets or sets the path to the containing folder of the design.
        /// </summary>
        [Browsable(false)]
        [JsonIgnore]
        public string Path { get; set; }
    }
}
