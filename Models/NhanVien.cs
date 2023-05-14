using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNHOM15.Models
{
    public class NhanVien
    {
        [Key]
        [Required]
        [Display( Name = "Mã NV")]
        public string? MaID{get; set;}
        [Required]
        [Display( Name = "Tên NV")]
        public string? TenNV{get; set;}

         [Required]
         [Display( Name = "Địa chỉ")]
        public string? Address{get; set;}

        [Required]
        [MinLength(10)]
        [Display( Name = "số điện thoại")]
        public string? SĐT{get; set;}
        
        [Required]
        [StringLength(12)]
        [Display( Name = "email NV")]
        public string? EmailNV{get; set;}

        [Required]
        [Display( Name = "Chức vụ")]
        public string? MaChucVu{get; set;}
         [ForeignKey("MaChucVu")]
       public ChucVu? ChucVu{get; set;}
          
    }
}