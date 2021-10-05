using Sat.Recruitment.Core.Abstraction;
using Sat.Recruitment.Core.Enumerator;
using Sat.Recruitment.Core.Factories;
using Xunit;

namespace Sat.Recruitment.Test.SuperUserMoneyTest
{
    public class SuperUserMoneyTest
    {
        IUserMoneyResolverFactory _resolverFactory;

        public SuperUserMoneyTest()
        {
            _resolverFactory = new UserMoneyResolverFactory();
        }


        [Fact]
        public void SuperUser_Deberia_Ser_20_Porciento_Mas()
        {
            //Arrange
            decimal money = 100;
            //Fact
            decimal result = _resolverFactory.Resolve(UserTypes.SuperUser).CalculateUserMoneyAmount(money);
            //Assert
            Assert.Equal(120, result);
        }

    }
}
