using System.Drawing;

namespace VisualAzureStudio.Models.Components
{
    public class KeyVault : ComponentBase
    {
        public override string TypeDescription => "Key Vault";
        public override int ImageIndex => 1;
        public override Color BackColor => Color.FromArgb(255, 255, 247, 219);
    }
}
