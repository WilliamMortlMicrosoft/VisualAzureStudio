using System;
using System.Collections.Generic;
using System.ComponentModel;
using VisualAzureStudio.Models.Components;
using VisualAzureStudio.Models.Connections;

namespace VisualAzureStudio.Models
{
    public class Design
    {
        [Browsable(false)]
        public Guid ResourceGroupId { get; set; }

        public Guid SubscriptionId { get; set; }

        public List<ResourceGroup> ResourceGroups { get; set; }

        public List<ServicePrincipal> RuntimeServicePrincipals { get; set; }

        public List<ServicePrincipal> DeploymentServicePrincipals { get; set; }

        [Browsable(false)]
        public List<ComponentBase> Components { get; set; } = new List<ComponentBase>();

        [Browsable(false)]
        public List<ConnectionBase> Connections { get; set; } = new List<ConnectionBase>();

        public List<KeyValuePair<string, string>> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the path to the containing folder of the design.
        /// </summary>
        public string Path { get; set; }

    }
}
