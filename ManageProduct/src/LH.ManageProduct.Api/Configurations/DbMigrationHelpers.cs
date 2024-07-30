using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Business.Models;

public static class DbMigrationHelpers
{
    public static async Task EnsureSeedData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var departmentService = scope.ServiceProvider.GetRequiredService<IDepartamentService>();
        var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

        await EnsureSeedDepartments(departmentService);
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
