using Dapper;
using EmployeeCrudDapper.entities;
using EmployeeCrudDapper.factories.queries;
using EmployeeCrudDapper.services.gateways;
using EmployeeCrudDapper.shared.dapper;
using EmployeeCrudDapper.shared.interfaces;

namespace EmployeeCrudDapper.services;

public class EmployeeService : IBaseService<Employee, int>
{
    private readonly IDatabaseConnection _databaseConnection;

    public EmployeeService(IDatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        using var db = await _databaseConnection.CreateConnectionAsync();
        return db.Query<Employee>(Query.GET_ALL).ToList();
    }

    public async Task<Employee> GetById(int entityId)
    {
        using var db = await _databaseConnection.CreateConnectionAsync();
        try
        {
            var employee = await db.QuerySingleOrDefaultAsync<Employee>(Query.GET_BY_ID, new { Id = entityId });
            return employee;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Employee> Create(Employee entity)
    {
        var parameters = UseDapper.DynamicParameters(entity);
        using var db = await _databaseConnection.CreateConnectionAsync();
        await db.ExecuteAsync(Query.POST, parameters);
        return NewEmployee(entity);
    }

    public async Task<Employee> Update(int entityId, Employee entity)
    {
        var parameters = UseDapper.DynamicParameters(entity, entityId);
        using var db = await _databaseConnection.CreateConnectionAsync();
        try
        {
            await db.ExecuteAsync(Query.UPDATE, parameters);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return NewEmployee(entity);
    }

    public async Task Delete(Employee entity, int entityId)
    {
        var parameters = UseDapper.PickedDynamicParameters(entity, entityId);
        using var db = await _databaseConnection.CreateConnectionAsync();
        await db.ExecuteAsync(Query.DELETE, parameters);
    }

    public async Task<IEnumerable<Employee>> GetAllDeleted()
    {
        using var db = await _databaseConnection.CreateConnectionAsync();
        return db.Query<Employee>(Query.GET_ALL_DELETED).ToList();
    }

    private static Employee NewEmployee(Employee entity)
    {
        var newEmployee = new Employee
        {
            Name = entity.Name,
            EmployeeCode = entity.EmployeeCode,
            Email = entity.Email,
            Age = entity.Age,
            StartDate = entity.StartDate
        };
        return newEmployee;
    }
}