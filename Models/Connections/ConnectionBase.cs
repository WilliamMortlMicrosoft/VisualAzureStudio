using System;
using System.ComponentModel;
using System.Drawing;
using Newtonsoft.Json;

namespace VisualAzureStudio.Models.Connections
{
    public class ConnectionBase
    {
        [Browsable(false)]
        public Guid Item1Id { get; set; }

        [Browsable(false)]
        public Guid Item2Id { get; set; }

        [Browsable(false)]
        [JsonIgnore]
        public Point Start { get; set; }

        [Browsable(false)]
        [JsonIgnore]
        public Point End { get; set; }
    }
}
