using ADAA.ADP.Application.Contracts;
using ADAA.ADP.Domain.Common;
using ADAA.ADP.Domain.Entities.Task;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADP.ADAA.Persistence
{
    public class ADAADbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public ADAADbContext(DbContextOptions<ADAADbContext> options)
           : base(options)
        {
        }

        public ADAADbContext(DbContextOptions<ADAADbContext> options, ILoggedInUserService loggedInUserService)
           : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.created_date = DateTime.Now;
                        entry.Entity.created_by = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.modified_date = DateTime.Now;
                        entry.Entity.modified_by = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
