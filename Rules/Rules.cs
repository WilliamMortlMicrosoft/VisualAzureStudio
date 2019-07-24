using System.Collections.Generic;
using System.Linq;
using VisualAzureStudio.Models;
using VisualAzureStudio.Models.Components;
using VisualAzureStudio.Models.Connections;

namespace VisualAzureStudio.Rules
{
    internal static class Rules
    {
        /// <summary>
        /// Returns a list of violations that would keep the design from being successfully deployed.
        /// </summary>
        /// <param name="design">Design to check for violations.</param>
        /// <returns></returns>
        internal static List<Violation> GetViolations(this Design design)
        {
            List<Violation> results = new List<Violation>();

            if ((design?.Components?.Count ?? 0) == 0) {
                return results;
            }

            // check for SQL databases not connected to SQL servers

            List<SqlServer> sqlServers = design.Components.OfType<SqlServer>().ToList();
            List<SqlDatabase> sqlDatabases = design.Components.OfType<SqlDatabase>().ToList();
            List<SqlDatabaseSqlServerConnection> sqlConnections = design.Connections.OfType<SqlDatabaseSqlServerConnection>().ToList();

            // get a list of connection objects are are connecting one SQL server and one SQL database

            List<SqlDatabaseSqlServerConnection> validSqlConnections = sqlConnections.Where(con => sqlServers.Any(s => s.Id == con.Item1Id) && sqlDatabases.Any(d => d.Id == con.Item2Id) || sqlDatabases.Any(d => d.Id == con.Item1Id) && sqlServers.Any(s => s.Id == con.Item2Id)).ToList();

            foreach (SqlDatabase sqlDatabase in design.Components.OfType<SqlDatabase>().Where(d => validSqlConnections.All(c => c.Item1Id != d.Id && c.Item2Id != d.Id))) {
                results.Add(
                    new Violation {
                        ItemId = sqlDatabase.Id,
                        Description = $"SQL Database \"{sqlDatabase.Name}\" must be connected to a SQL Server object."
                    }
                );
            }

            return results;
        }
    }
}
