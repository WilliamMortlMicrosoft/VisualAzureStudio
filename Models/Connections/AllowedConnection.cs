using System;
using System.Collections.Generic;
using VisualAzureStudio.Models.Components;

namespace VisualAzureStudio.Models.Connections
{
    public class AllowedConnection : Tuple<Type, Type, Type>
    {
        public AllowedConnection(Type item1, Type item2, Type item3) : base(item1, item2, item3) { }
    }

    public class AllowedConnections : List<AllowedConnection>
    {
        public static List<AllowedConnection> Allowed { get; } = new List<AllowedConnection> {
            new AllowedConnection(typeof(Msi), typeof(SqlDatabase), typeof(MsiSqlDatabaseConnection)),
            new AllowedConnection(typeof(Msi), typeof(Aks), typeof(MsiAksConnection)),
            new AllowedConnection(typeof(Msi), typeof(KeyVault), typeof(MsiKeyVaultConnection)),
            new AllowedConnection(typeof(SqlDatabase), typeof(SqlServer), typeof(SqlDatabaseSqlServerConnection)),
            new AllowedConnection(typeof(AppService), typeof(Msi), typeof(MsiAppServiceConnection))
        };
    }
}
