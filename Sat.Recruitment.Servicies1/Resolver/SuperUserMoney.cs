using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Servicies.Resolver
{
    public class SuperUserMoney : IUserMoneyResolver
    {
        public decimal CalculateUserMoneyAmount(decimal money)
        {
            decimal result;
            var percentage = Convert.ToDecimal(0.20);
            var gif = money * percentage;
            result = money + gif;
            return result;
        }
    }
}
