using Sat.Recruitment.Core.Abstraction;
using Sat.Recruitment.Core.Enumerator;
using Sat.Recruitment.Core.Resolver;

namespace Sat.Recruitment.Core.Factories
{
    public class UserMoneyResolverFactory : IUserMoneyResolverFactory
    {
        public IUserMoneyResolver Resolve(UserTypes userType)
        {
            IUserMoneyResolver strategy;
            switch (userType)
            {
                case UserTypes.Normal:
                    strategy = new NormalUserMoney();
                    break;
                case UserTypes.SuperUser:
                    strategy = new SuperUserMoney();
                    break;
                case UserTypes.Premium:
                    strategy = new PremiumUserMoney();
                    break;
                default:
                    strategy = new NormalUserMoney();
                    break;
            }

            return strategy;
        }


    }
}
