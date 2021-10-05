using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Servicies.Resolver
{
    public class PremiumUserMoney : IUserMoneyResolver
    {
        public decimal CalculateUserMoneyAmount(decimal money)
        {
            decimal result = money;

            if (money > 100)
            {
                var gif = money * 2;
                result = money + gif;
            }

            return result;
        }
    }
}
