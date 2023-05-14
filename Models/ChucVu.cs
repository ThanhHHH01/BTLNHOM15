using System.ComponentModel.DataAnnotations;
namespace BTLNHOM15.Models
{
    public class ChucVu
    {
        [Key]
        public string? MaChucVu{get; set;}
        public string? TenChucVu{get; set;}
    }
}