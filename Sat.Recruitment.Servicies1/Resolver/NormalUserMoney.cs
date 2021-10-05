using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Servicies.Resolver
{
    public class NormalUserMoney : IUserMoneyResolver
    {
        public decimal CalculateUserMoneyAmount(decimal money)
        {
            decimal result = money;
            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                var gif = money * percentage;
                result = money + gif;
            }
            else
            {
                if (money <= 100 && money > 10)
                {
                    var percentage = Convert.ToDecimal(0.8);
                    var gif = money * percentage;
                    result = money + gif;
                }
            }

            return result;
        }
    }
    }
}
