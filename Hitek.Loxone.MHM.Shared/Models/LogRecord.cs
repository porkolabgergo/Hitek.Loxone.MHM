using System.ComponentModel.DataAnnotations;
using Hitek.Loxone.MHM.Shared.Enums;

namespace Hitek.Loxone.MHM.Shared.Models;

public class LogRecord
{
    [Key]
    public Guid Id { get; set; }
    public LogType LogType { get; set; }
    public Employee? Employee { get; set; }
    public DateTime Date { get; set; }
}