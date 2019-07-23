using System.ComponentModel;
using System.Drawing;

namespace VisualAzureStudio.Models.Components
{
    public class Aks : ComponentBase
    {
        public ServicePrincipal ServicePrincipal { get; set; } = new ServicePrincipal();

        [Description("Number of nodes in this service.")]
        public int NodeCount { get; set; } = 1;
        public override string TypeDescription => "AKS";
        public override int ImageIndex => 4;
        public override Color BackColor => Color.FromArgb(255, 244, 219, 244);
    }
}
