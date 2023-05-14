using System.ComponentModel.DataAnnotations;
namespace BTLNHOM15.Models
{
    public class GiaGoi
    {
        [Key]
        public string? MaGiaGoi{get; set;}
        public string? TenGoi{get; set;}
    }
}