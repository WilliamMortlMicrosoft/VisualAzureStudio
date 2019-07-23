using System;
using System.ComponentModel;

namespace VisualAzureStudio.Models
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ServicePrincipal
    {
        [Browsable(false)]
        public Guid Id { get; set; }

        [Description("Name of this service principal.")]
        public string Name { get; set; }

        [Description("Password/client secret for this service principal.")]
        public string Password { get; set; }

        [Description("ID of the Azure tenant containing this service principal.")]
        public Guid TenantId { get; set; }
    }
}
