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
        catch (Exception)
        {
            //TODO : Log exception
        }
        return null;
    }

    public Employee GetEmployee(string id)
    {
        return db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
    }

    public void AddEmployee(Employee e)
    {
        try
        {
            db.Employees.Add(e);
            db.SaveChanges();
        }
        catch
        {
            //TODO: Log exception
        }
    }
    
    public void UpdateEmployee(Employee e)
    {
        try
        {
            db.Entry(e).State = EntityState.Modified;
            db.SaveChanges();
        }
        catch
        {
            //TODO: Log exception
        }
    }

    public void DeleteEmployee(string id)
    {
        try
        {
            Employee e = db.Employees.Find(id);
            db.Employees.Remove(e);
            db.SaveChanges();
        }
        catch
        {
            //TODO: Log exception
        }
    }
}