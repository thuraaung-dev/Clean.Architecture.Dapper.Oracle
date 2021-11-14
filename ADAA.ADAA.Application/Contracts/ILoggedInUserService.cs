using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Application.Contracts
{
    public interface ILoggedInUserService
    {
        public string UserId { get; }
    }
}
