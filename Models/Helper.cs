using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VisualAzureStudio.Models.Components;
using VisualAzureStudio.Models.Connections;

namespace VisualAzureStudio.Models
{
    class Helper
    {
        public static bool GenerateAZ(Design design, string outputFolder)
        {
            bool ret = true;
            if (design != null)
            {
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }
                using (StreamWriter fileWriter = new StreamWriter(Path.Combine(outputFolder, "azcommands.txt")))
                {
                    foreach (string resgroup in design.Components.Select(c => c.ResourceGroup).Distinct())
                    {
                        string region = design.GetMostPopularRegion(resgroup).ToString();
                        // Create resource group command
                        string createRG = "az group create -l " + region + " -n " + resgroup;
                        fileWriter.WriteLine(createRG);
                    }

                    foreach (Aks aks in design.Components.OfType<Aks>())
                    {
                        // Create AKS command
                        string createAKS = "az aks create --resource-group " + aks.ResourceGroup + " --name " + aks.Name +
                            " --node-count " + aks.NodeCount + " --service-principal " + aks.ServicePrincipal.TenantId + " --client-secret "
                            + aks.ServicePrincipal.Password + " --generate-ssh-keys --location " + aks.Region;
                        fileWriter.WriteLine(createAKS);
                    }

                    foreach (Msi msi in design.Components.OfType<Msi>())
                    {
                        // Create MSI command
                        string createMSI = "az identity create --resource-group " + msi.ResourceGroup + " --name " + msi.Name + " -o json";
                        fileWriter.WriteLine(createMSI);
                    }

                    foreach (SqlServer sqlserver in design.Components.OfType<SqlServer>())
                    {
                        // Create SQL server command
                        string createserver = "az sql server create --admin-password " + sqlserver.AdministrationPassword +
                            " --admin-user " + sqlserver.AdministrationName + " --name " + sqlserver.Name + " --resource-group "
                            + sqlserver.ResourceGroup;
                        fileWriter.WriteLine(createserver);
                    }

                    foreach (SqlDatabase db in design.Components.OfType<SqlDatabase>())
                    {
                        // Find its corresponding sql server
                        SqlDatabaseSqlServerConnection conn = design.Connections.OfType<SqlDatabaseSqlServerConnection>().
                            FirstOrDefault(c => c.Item1Id == db.Id || c.Item2Id == db.Id);
                        SqlServer server = design.Components.OfType<SqlServer>().FirstOrDefault(c => c.Id == conn.Item1Id || c.Id == conn.Item2Id);
                        // Create sql db command
                        string createDB = "az sql db create --name " + db.Name + " --resource-group " + db.ResourceGroup
                            + " --server " + server.Name;
                        fileWriter.WriteLine(createDB);
                    }

                    foreach (KeyVault keyvault in design.Components.OfType<KeyVault>())
                    {
                        // Create key vault command
                        string createKV = "az keyvault create --name " + keyvault.Name + " --resource-group " +
                            keyvault.ResourceGroup + " --location " + keyvault.Region;
                        fileWriter.WriteLine(createKV);
                    }

                    foreach (AppService app in design.Components.OfType<AppService>())
                    {
                        // Create web app and service plan command
                        string createServicePlan = "az appservice plan create --name " + app.Name + "_plan --resource-group " +
                            app.ResourceGroup + " --location " + app.Region + " --sku S1";
                        fileWriter.WriteLine(createServicePlan);
                        string createWebApp = "az webapp create --name " + app.Name + " --resource-group " + app.ResourceGroup
                            + " --plan " + app.Name + "_plan";
                        fileWriter.WriteLine(createWebApp);
                    }
                }
            }

            return ret;
        }
    }
}
