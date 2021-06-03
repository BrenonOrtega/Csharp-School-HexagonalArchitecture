using System.Data;

namespace FirstDataAccess.Helpers
{
    internal interface IConnectionHelper
    {
        IDbConnection GetDbConnection(string name);

    }
}