using Hitek.Loxone.MHM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hitek.Loxone.MHM.WebAPI.Context;

public class LogRecordContext : DbContext
{
    public virtual DbSet<LogRecord> LogRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Hitek.Loxone;User Id=sqladmin;Password=Wuv1ac2aT;TrustServerCertificate=True");
        }
    }
}