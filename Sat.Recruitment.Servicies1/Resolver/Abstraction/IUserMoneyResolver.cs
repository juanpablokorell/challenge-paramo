using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Servicies.Resolver
{
    public interface IUserMoneyResolver
    {
        decimal CalculateUserMoneyAmount(decimal money);
    }
}
