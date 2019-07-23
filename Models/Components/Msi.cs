using System;
using System.Collections.Generic;
using System.Drawing;

namespace VisualAzureStudio.Models.Components
{
    public class Msi : ComponentBase
    {
        // Publish = Code or Docket Image
        // Runtime stack
        // Operation System = Linux or Windows
        // Region
        // App Service Plan Name
        // SKU
        public override string TypeDescription => "MSI";
        public override int ImageIndex => 3;
        public override Color BackColor => Color.LightCyan;
    }
}
