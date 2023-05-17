using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLNHOM15.Models
{
    public class TinhTrang
    {
        [Key]

        [Display( Name = "Mã tình trạng")]
        public string? MaTinhTrang{get; set;}

        [Display( Name = "Tên thiết bị")]
        public string? MaTB{get; set;}
        [ForeignKey("MaTB")]
        public ThietBi? ThietBi{get; set;}
       
        [Display( Name = "Tình trạng thiết bị")]
        public string? TinhTrangND { get; set; }
         
    }
}