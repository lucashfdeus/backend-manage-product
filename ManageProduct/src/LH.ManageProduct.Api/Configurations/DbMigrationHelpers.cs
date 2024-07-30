using Dapper;
using Npgsql;
using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Business.Models;

public static class DbMigrationHelpers
{
    public static async Task EnsureSeedData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var departmentService = scope.ServiceProvider.GetRequiredService<IDepartamentService>();
        var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        await CreateDatabaseSchemaAsync(connectionString);

        await EnsureSeedDepartments(departmentService);
    }

    private static async Task CreateDatabaseSchemaAsync(string connectionString)
    {
        try
        {
            using var connection = new NpgsqlConnection(connectionString);

            var createExtension = @"
            CREATE EXTENSION IF NOT EXISTS ""uuid-ossp"";
            ";

            var createTables = @"
            CREATE TABLE IF NOT EXISTS Departments (
                Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                Code VARCHAR(50) NOT NULL UNIQUE,
                Description TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Products (
                Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                Description TEXT NOT NULL,
                DepartmentCode VARCHAR(50) REFERENCES Departments(Code) ON DELETE SET NULL,
                Price NUMERIC(18, 2) NOT NULL,
                Status BOOLEAN DEFAULT TRUE
            );

            CREATE INDEX IF NOT EXISTS idx_department_code ON Products (DepartmentCode);
            ";

            await connection.ExecuteAsync(createExtension);
            await connection.ExecuteAsync(createTables);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while creating the database schema: {ex.Message}");
        }
    }

    private static async Task EnsureSeedDepartments(IDepartamentService departmentService)
    {
        var existingDepartments = await departmentService.GetAllDepartment();

        if (existingDepartments.Any())
            return;

        var departments = new[]
        {
            new Department { Id = Guid.NewGuid(), Code = "010", Description = "BEBIDAS" },
            new Department { Id = Guid.NewGuid(), Code = "020", Description = "CONGELADOS" },
            new Department { Id = Guid.NewGuid(), Code = "030", Description = "LATICINIOS" },
            new Department { Id = Guid.NewGuid(), Code = "040", Description = "VEGETAIS" }
        };

        await departmentService.CreateDepartmentsAsync(departments);
    }
}
