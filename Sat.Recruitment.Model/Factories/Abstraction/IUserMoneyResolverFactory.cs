using Sat.Recruitment.Core.Enumerator;
using Sat.Recruitment.Core.Resolver;

namespace Sat.Recruitment.Core.Abstraction
{
    public interface IUserMoneyResolverFactory
    {
        IUserMoneyResolver Resolve(UserTypes userType);
    }
}
