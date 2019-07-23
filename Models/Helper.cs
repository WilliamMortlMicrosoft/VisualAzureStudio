using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualAzureStudio.Models.Components;

namespace VisualAzureStudio.Models
{
    class Helper
    {
        public static bool GenerateARM(Design design, string outputFolder)
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
                    
                    foreach (KeyVault keyvault in design.Components.OfType<KeyVault>())
                    {
                        // Create key vault command
                        string createKV = "az keyvault create --name " + keyvault.Name + " --resource-group " +
                            keyvault.ResourceGroup + " --location " + keyvault.Region;
                        fileWriter.WriteLine(createKV);
                    }

                }

            }

            return ret;
        }
    }
}
