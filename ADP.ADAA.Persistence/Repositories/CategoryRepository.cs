using Dapper;
using ADAA.ADP.Application.Contracts.Persistence;
using ADAA.ADP.Domain.Entities.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Dapper.Oracle;
using ADAA.ADP.Application.Contracts;

namespace ADP.ADAA.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private IDbConnection _db;
        private readonly ILoggedInUserService _loggedInUserService;
        public CategoryRepository(ADAADbContext dbContext, IConfiguration configuration, ILoggedInUserService loggedInUserService) : base(dbContext, configuration)
        {
            this._db = new OracleConnection(configuration.GetConnectionString("ADAAConnectionString"));
            this._loggedInUserService = loggedInUserService;
        }
        public async Task<Category> GetByIdAsync(decimal id)
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("@P_CATEGORY_ID", id, dbType: OracleMappingType.Int32, ParameterDirection.Input);
            parameters.Add("@P_REFCURSOR_OUT", null, OracleMappingType.RefCursor, ParameterDirection.Output);

            return await _db.QueryFirstAsync<Category>("LOOKUPS_PKG.GET_TASK_CATEGORIES_BY_ID_PRC", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<List<Category>> GetCategoriesWithDeptId(string last_dept_id)
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("@P_CATEGORY_DEPARTMENT_ID", last_dept_id, dbType: OracleMappingType.Int32, ParameterDirection.Input);
            parameters.Add("@P_REFCURSOR_OUT", null, OracleMappingType.RefCursor, ParameterDirection.Output);

            return (await _db.QueryAsync<Category>("LOOKUPS_PKG.GET_TASK_CATEGORIES_PRC", parameters, commandType: CommandType.StoredProcedure)).ToList();
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("@P_CATEGORY_NAME_AR", category.CATEGORY_NAME_AR, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_CATEGORY_NAME_EN", category.CATEGORY_NAME_EN, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_CATEGORY_DESC_AR", category.CATEGORY_DESC_AR, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_CATEGORY_DESC_EN", category.CATEGORY_DESC_EN, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_CATEGORY_DEPARTMENT_ID", category.CATEGORY_DEPARTMENT_ID, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_CREATED_BY", _loggedInUserService.UserId, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_ID_OUT", null, OracleMappingType.Int32, ParameterDirection.Output);

            var result = await _db.ExecuteAsync("LOOKUPS_PKG.ADD_TASK_CATEGORY_PRC", parameters, commandType: CommandType.StoredProcedure);

            return result;
        }
        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("@P_CATEGORY_ID", category.CATEGORY_ID, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_CATEGORY_NAME_AR", category.CATEGORY_NAME_AR, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_CATEGORY_NAME_EN", category.CATEGORY_NAME_EN, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_CATEGORY_DESC_AR", category.CATEGORY_DESC_AR, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_CATEGORY_DESC_EN", category.CATEGORY_DESC_EN, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_CATEGORY_DEPARTMENT_ID", category.CATEGORY_DEPARTMENT_ID, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_IS_ACTIVE", category.IS_ACTIVE, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("@P_MODIFIED_BY", _loggedInUserService.UserId, dbType: OracleMappingType.Varchar2, ParameterDirection.Input);

            await _db.ExecuteAsync("LOOKUPS_PKG.UPDATE_TASK_CATEGORY_PRC", parameters, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
