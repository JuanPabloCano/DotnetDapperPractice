namespace EmployeeCrudDapper.factories.queries;

public static class Query
{
    public static readonly string GET_ALL = "SELECT * FROM employee WHERE IsActive = true";
    public static readonly string GET_BY_ID = "SELECT * FROM employee WHERE Id=@Id";

    public static readonly string POST =
        "INSERT INTO employee(name, employeeCode,email, age, startDate) VALUES(@name, @employeeCode, @email, @age, @startDate)";

    public static readonly string UPDATE =
        "UPDATE employee SET name=@name, employeeCode=@employeeCode, email=@email, age=@age, startDate=@startDate WHERE Id = @Id";

    public static readonly string DELETE = "UPDATE employee SET endDate=@endDate, isActive=@isActive WHERE Id=@Id";
    public static readonly string GET_ALL_DELETED = "SELECT * FROM employee WHERE isActive=false";
}