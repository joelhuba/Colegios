using System.Data.SqlClient;

namespace Colegios.Core.Interfaces.Services
{
    public interface ISqlCommandService
    {
        void AddParameters<T>(SqlCommand command, T parameters);
    }
}
