using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HGH_Webesite.Models;

namespace HGH_Webesite.Data
{
    public class HGH_WebesiteContext : DbContext
    {
        public HGH_WebesiteContext (DbContextOptions<HGH_WebesiteContext> options)
            : base(options)
        {
        }

        public DbSet<HGH_Webesite.Models.HomePage> HomePage { get; set; }

        public DbSet<HGH_Webesite.Models.NewsPage> NewsPage { get; set; }

        public DbSet<HGH_Webesite.Models.Seeingnews> Seeingnews { get; set; }

        public DbSet<HGH_Webesite.Models.StatsticsPage> StatisticsPage { get; set; }

        public DbSet<HGH_Webesite.Models.NonModle> NonModle { get; set; }
    }
}
