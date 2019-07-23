using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Newtonsoft.Json;

namespace VisualAzureStudio.Models.Components
{
    public abstract class ComponentBase
    {
        [Browsable(false)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ResourceGroupId { get; set; }

        [Description("Name of this object.")]
        public string Name { get; set; }

        [Browsable(false)]
        public Point Location { get; set; }

        public Regions Region { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public abstract string TypeDescription { get; }

        [JsonIgnore]
        [Browsable(false)]
        public abstract int ImageIndex { get; }

        [JsonIgnore]
        [Browsable(false)]
        public abstract Color BackColor { get; }
    }
}
