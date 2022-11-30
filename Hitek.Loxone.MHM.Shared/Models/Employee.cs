using System.ComponentModel.DataAnnotations;

namespace Hitek.Loxone.MHM.Shared.Models;

public class Employee
{
    [Key]
    public string? EmployeeID { get; set; }
    public string? Vorname { get; set; }
    public string? Nachname { get; set; }
    public bool IsCheckedIn { get; set; }
}