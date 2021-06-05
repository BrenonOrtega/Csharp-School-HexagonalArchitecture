using System.Data;

namespace FirstDataAccess.Helpers
{
    public interface IConnectionHelper
    {
        string CnnStringName { get; }
        IDbConnection GetDbConnection();
    }
}