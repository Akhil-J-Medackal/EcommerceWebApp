using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Data
{
    public class DataAuthContext:IdentityDbContext
    {
        public DataAuthContext(DbContextOptions<DataAuthContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminId="eb8f76d4-456c-4c1b-9fef-fc08a6fc6d5d";
            var buyerId="7c825905-7946-466e-a049-62e90fdcf22c";
            var sellerId="6b8d9344-93c6-46df-808d-a6177bb7781b";
            var roles=new List<IdentityRole>
            {
                new IdentityRole{
                    Id=adminId,
                    ConcurrencyStamp=adminId,
                    Name="Admin",
                    NormalizedName="Admin".ToUpper()
                },
                new IdentityRole{
                    Id=buyerId,
                    ConcurrencyStamp=buyerId,
                    Name="Buyer",
                    NormalizedName="Buyer".ToUpper()
                },
                new IdentityRole{
                    Id=sellerId,
                    ConcurrencyStamp=sellerId,
                    Name="Seller",
                    NormalizedName="Seller".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}