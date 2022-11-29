using Hitek.Loxone.MHM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hitek.Loxone.MHM.WebAPI.Context;

public class EmployeeContext : DbContext
{
    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='F:\blazor\EFGrid - CRUD - P6\EFGrid.Shared\App_Data\NORTHWND.MDF';Integrated Security=True;Connect Timeout=30");
        }
}