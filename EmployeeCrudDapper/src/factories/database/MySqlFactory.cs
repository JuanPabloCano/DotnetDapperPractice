using System.Data;
using EmployeeCrudDapper.shared.interfaces;
using MySql.Data.MySqlClient;

namespace EmployeeCrudDapper.factories.database;

public class MySqlFactory : IDatabaseConnection
{
    private readonly string _connectionString;

    public MySqlFactory(string connectionString) =>
        _connectionString = connectionString ?? throw new ArgumentException(null, nameof(connectionString));

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var mySqlConnection = new MySqlConnection(_connectionString);
        await mySqlConnection.OpenAsync();
        return mySqlConnection;
    }
}