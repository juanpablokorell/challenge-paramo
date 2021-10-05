using Sat.Recruitment.Core.Enum;
using Sat.Recruitment.Servicies.Abstraction;
using Sat.Recruitment.Servicies.Resolver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Servicies.Factories
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
