using ADP.ADAA.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP.ADAA.Identity
{
    public class ADAAIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
         public ADAAIdentityDbContext(DbContextOptions<ADAAIdentityDbContext> options) : base(options)
    {
    }
}
}
