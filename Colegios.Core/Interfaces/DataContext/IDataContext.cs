using System.Data.SqlClient;

namespace Colegios.Core.Interfaces.DataContext
{
    public interface IDataContext
    {
        SqlConnection GetConnection();
        SqlCommand CreateCommand();
    }
}
