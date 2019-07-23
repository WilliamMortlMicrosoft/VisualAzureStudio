using System;
using System.Collections.Generic;
using System.Drawing;

namespace VisualAzureStudio.Models.Components
{
    public class Aks : ComponentBase
    {
        public ServicePrincipal ServicePrincipal { get; set; }
        public override string TypeDescription => "AKS";
        public override int ImageIndex => 4;
        public override Color BackColor => Color.PeachPuff;
    }
}
