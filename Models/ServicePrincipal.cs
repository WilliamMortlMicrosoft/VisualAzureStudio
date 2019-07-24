using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace VisualAzureStudio.Models
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonConverter(typeof(NoTypeConverterJsonConverter<ServicePrincipal>))]
    public class ServicePrincipal
    {
        [Browsable(false)]
        public Guid Id { get; set; }

        [Description("Name of this service principal.")]
        public string Name { get; set; } = string.Empty;

        [Description("Password/client secret for this service principal.")]
        public string Password { get; set; } = string.Empty;

        [Description("ID of the Azure tenant containing this service principal.")]
        public Guid TenantId { get; set; }
    }
}
