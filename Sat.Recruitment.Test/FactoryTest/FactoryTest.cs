using Sat.Recruitment.Core.Abstraction;
using Sat.Recruitment.Core.Enumerator;
using Sat.Recruitment.Core.Factories;
using Sat.Recruitment.Core.Resolver;
using Xunit;

namespace Sat.Recruitment.Test.FactoryTest
{
    public class FactoryTest
    {
        private IUserMoneyResolverFactory _factory;

        public FactoryTest()
        {
            _factory = new UserMoneyResolverFactory();
        }

        [Fact]
        public void Factory_SuperUser_Test()
        {
            //Arrange
            var userType = UserTypes.SuperUser;
            //Fact
            var result = _factory.Resolve(userType);
            //Assert
            Assert.True(result is SuperUserMoney);
        }
        [Fact]
        public void Factory_NormalUser_Test()
        {
            //Arrange
            var userType = UserTypes.Normal;
            //Fact
            var result = _factory.Resolve(userType);
            //Assert
            Assert.True(result is NormalUserMoney);
        }
        [Fact]
        public void Factory_PremiumUser_Test()
        {
            //Arrange
            var userType = UserTypes.Premium;
            //Fact
            var result = _factory.Resolve(userType);
            //Assert
            Assert.True(result is PremiumUserMoney);
        }
    }
}
