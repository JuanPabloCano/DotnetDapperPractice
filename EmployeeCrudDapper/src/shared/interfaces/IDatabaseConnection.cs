using System.Data;

namespace EmployeeCrudDapper.shared.interfaces;

public interface IDatabaseConnection
{
    Task<IDbConnection> CreateConnectionAsync();
}