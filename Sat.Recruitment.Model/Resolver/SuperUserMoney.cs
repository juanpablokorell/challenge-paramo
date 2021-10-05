using System;

namespace Sat.Recruitment.Core.Resolver
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
