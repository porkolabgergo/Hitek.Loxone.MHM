using Hitek.Loxone.MHM.Shared.Models;
using Hitek.Loxone.MHM.WebAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace Hitek.Loxone.MHM.WebAPI.Repositories;

public class LogRecordRepository
{
    private LogRecordContext db = new();

    public DbSet<LogRecord> GetAllLogRecords()
    {
        try
        {
            return db.LogRecords;
        }
        catch (Exception)
        {
            //TODO : Log exception
        }
        return null;
    }

    public void AddLogRecord(LogRecord l)
    {
        try
        {
            db.LogRecords.Add(l);
            db.SaveChanges();
        }
        catch
        {
            //TODO: Log exception
        }
    }
    
    public void UpdateLogRecord(LogRecord l)
    {
        try
        {
            db.Entry(l).State = EntityState.Modified;
            db.SaveChanges();
        }
        catch
        {
            //TODO: Log exception
        }
    }

    public void DeleteLogRecord(string id)
    {
        try
        {
            LogRecord l = db.LogRecords.Find(id);
            db.LogRecords.Remove(l);
            db.SaveChanges();
        }
        catch
        {
            //TODO: Log exception
        }
    }
}