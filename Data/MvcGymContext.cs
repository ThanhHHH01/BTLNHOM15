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
    }
