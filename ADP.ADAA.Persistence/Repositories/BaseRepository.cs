using ADAA.ADP.Application.Contracts.Persistence;
using ADAA.ADP.Domain.Entities.Task;
using Dapper;
using Dapper.Oracle;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP.ADAA.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ADAADbContext _dbContext;
        private IDbConnection _db;

        
        public BaseRepository(ADAADbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            this._db = new OracleConnection(configuration.GetConnectionString("ADAAConnectionString"));
        }
        public async Task<IReadOnlyList<T>> GetByParentIdAsync(string spName, object param)
        {
            return (await _db.QueryAsync<T>(spName, param, commandType: CommandType.StoredProcedure)).ToList();
        }

    }
}
