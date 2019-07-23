using System;
using System.Collections.Generic;
using VisualAzureStudio.Models.Components;

namespace VisualAzureStudio.Models.Connections
{
    public class AllowedConnection : Tuple<Type, Type>
    {
        public AllowedConnection(Type item1, Type item2) : base(item1, item2) { }
    }

    public class AllowedConnections : List<AllowedConnection>
    {
        public static List<AllowedConnection> Allowed { get; } = new List<AllowedConnection> {
            new AllowedConnection(typeof(Msi), typeof(SqlDatabase))
        };
    }
}
