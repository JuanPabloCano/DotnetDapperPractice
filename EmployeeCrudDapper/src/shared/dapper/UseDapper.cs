using System.Data;
using System.Runtime.InteropServices;
using Dapper;
using EmployeeCrudDapper.entities;

namespace EmployeeCrudDapper.shared.dapper;

public class UseDapper
{
    private static readonly DynamicParameters Parameters = new DynamicParameters();

    public static DynamicParameters DynamicParameters(Employee entity, [Optional] int entityId)
    {
        if (entityId is not 0)
        {
            Parameters.Add("Id", entityId);
        }

        Parameters.Add("name", entity.Name, DbType.String);
        Parameters.Add("employeeCode", entity.EmployeeCode, DbType.String);
        Parameters.Add("email", entity.Email, DbType.String);
        Parameters.Add("age", entity.Age, DbType.Int32);
        Parameters.Add("startDate", entity.StartDate, DbType.Date);
        Parameters.Add("endDate", entity.EndDate, DbType.Date);
        Parameters.Add("isActive", entity.IsActive, DbType.Boolean);
        return Parameters;
    }

    public static DynamicParameters PickedDynamicParameters(Employee employee, int id)
    {
        if (id is not 0)
        {
            Parameters.Add("Id", id);
        }

        Parameters.Add("endDate", employee.EndDate, DbType.Date);
        Parameters.Add("isActive", employee.IsActive, DbType.Boolean);
        return Parameters;
    }
}