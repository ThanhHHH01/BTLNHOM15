using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNHOM15.Models;

public class ThietBi
{
    [Key]
     [Required]
    public string? MaTB { get; set; }
    [Required]
    public string? TenTB { get; set; }
    [Required]
    public int size { get; set; }
    [Required]
     public int Soluong { get; set; }
    [Required]
    public decimal Giatien { get; set; }
}