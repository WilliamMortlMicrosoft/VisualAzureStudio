using System;
using System.Collections.Generic;
using System.Drawing;

namespace VisualAzureStudio.Models.Components
{
    public class KeyVault : ComponentBase
    {
        public Dictionary<string, string> Secrets { get; set; } = new Dictionary<string, string>();
        public override string TypeDescription => "Key Vault";
        public override int ImageIndex => 1;
        public override Color BackColor => Color.AntiqueWhite;
    }
}
