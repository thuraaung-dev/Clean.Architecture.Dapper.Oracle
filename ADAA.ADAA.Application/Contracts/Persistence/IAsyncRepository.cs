using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADAA.ADP.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
          Task<IReadOnlyList<T>> GetByParentIdAsync(string spName, object param);
    }
}
