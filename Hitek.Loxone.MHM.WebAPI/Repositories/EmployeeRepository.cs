using Hitek.Loxone.MHM.Shared.Models;
using Hitek.Loxone.MHM.WebAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace Hitek.Loxone.MHM.WebAPI.Repositories;

public class EmployeeRepository
{
    private EmployeeContext db = new();

    public DbSet<Employee> GetAllEmployees()
    {
        try
        {
            return db.Employees;
        }
        catch (Exception e)
        {
            //TODO : Log exception
        }
    }
    
}