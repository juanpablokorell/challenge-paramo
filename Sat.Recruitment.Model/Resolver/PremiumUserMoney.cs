namespace Sat.Recruitment.Core.Resolver
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
