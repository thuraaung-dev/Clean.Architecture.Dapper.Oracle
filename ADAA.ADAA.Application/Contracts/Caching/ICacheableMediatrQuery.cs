using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Contracts.Caching
{
    public interface ICacheableMediatrQuery
    {
        bool BypassCache { get; }
        string CacheKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
