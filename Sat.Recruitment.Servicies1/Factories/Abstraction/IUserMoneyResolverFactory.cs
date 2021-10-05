using Sat.Recruitment.Core.Enum;
using Sat.Recruitment.Servicies.Resolver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Servicies.Abstraction
{
    public interface IUserMoneyResolverFactory
    {
        IUserMoneyResolver Resolve(UserTypes userType);
    }
}
