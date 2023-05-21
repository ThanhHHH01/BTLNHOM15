using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTLNHOM15.Models;

    public class MvcGymContext : DbContext
    {
        public MvcGymContext (DbContextOptions<MvcGymContext> options)
            : base(options)
        {
        }

        public DbSet<BTLNHOM15.Models.NhanVien> NhanVien { get; set; } = default!;

        public DbSet<BTLNHOM15.Models.HoiVien> HoiVien { get; set; } = default!;

        public DbSet<BTLNHOM15.Models.ChucVu> ChucVu { get; set; } = default!;

        public DbSet<BTLNHOM15.Models.GoiTap> GoiTap { get; set; } = default!;

        public DbSet<BTLNHOM15.Models.TinhTrang> TinhTrang { get; set; } = default!;

        public DbSet<BTLNHOM15.Models.ThietBi> ThietBi { get; set; } = default!;

        public DbSet<BTLNHOM15.Models.ThanhToan> ThanhToan { get; set; } = default!;

        
    }
