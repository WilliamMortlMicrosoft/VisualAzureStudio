using System;
using System.Collections.Generic;
using System.Drawing;

namespace VisualAzureStudio.Models.Components
{
    public class AppService : ComponentBase
    {
        // Publish = Code or Docket Image
        // Runtime stack
        // Operation System = Linux or Windows
        // Region
        // App Service Plan Name
        // SKU
        public override string TypeDescription => "App Service";
        public override int ImageIndex => 0;
        public override Color BackColor => Color.AliceBlue;
    }
}
