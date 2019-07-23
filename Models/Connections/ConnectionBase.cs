using System;
using System.ComponentModel;
using System.Drawing;

namespace VisualAzureStudio.Models.Connections
{
    public class ConnectionBase
    {
        [Browsable(false)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Browsable(false)]
        public Guid Item1Id { get; set; }

        [Browsable(false)]
        public Guid Item2Id { get; set; }

        [Browsable(false)]
        public Point Start { get; set; }

        [Browsable(false)]
        public Point End { get; set; }
    }
}
