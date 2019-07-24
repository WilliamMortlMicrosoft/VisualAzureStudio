using System.ComponentModel;
using System.Drawing;

namespace VisualAzureStudio.Models.Components
{
    public class SqlServer : ComponentBase
    {
        [Description("Administrator name for this SQL Server.")]
        public string AdministrationName { get; set; } = "Administrator";

        [Description("Administrator password for this SQL Server.")]
        public string AdministrationPassword { get; set; } = "Password";

        public override string TypeDescription => "SQL Server";

        public override int ImageIndex => 5;

        public override Color BackColor => Color.Lavender;
    }
}
