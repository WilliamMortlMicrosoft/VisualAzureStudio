using System;

namespace VisualAzureStudio.Models.Connections
{
    public class MsiSqlDatabaseConnection : ConnectionBase
    {
        public bool CanImpersonate { get; set; }
    }
}
