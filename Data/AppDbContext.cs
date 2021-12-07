using Microsoft.EntityFrameworkCore;
using orderDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderDelivery.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<OrderModel> Orders { get; set; } // Создание таблицы Orders в БД
    }
}
