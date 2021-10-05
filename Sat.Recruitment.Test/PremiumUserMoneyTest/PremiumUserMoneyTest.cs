using Sat.Recruitment.Core.Abstraction;
using Sat.Recruitment.Core.Enumerator;
using Sat.Recruitment.Core.Factories;
using Xunit;

namespace Sat.Recruitment.Test.PremiumUserMoneyTest
{
    public class PremiumUserMoneyTest
    {
        IUserMoneyResolverFactory _resolverFactory;

        public PremiumUserMoneyTest()
        {
            _resolverFactory = new UserMoneyResolverFactory();
        }


        [Fact]
        public void PremiumUser_Money_Debe_Muplitiplicarse_Por_3_Si_Es_Mayor_A_100()
        {
            //Arrange
            decimal money = 201;
            //Fact
            decimal result = _resolverFactory.Resolve(UserTypes.Premium).CalculateUserMoneyAmount(money);
            //Asert
            Assert.Equal(603, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(99)]
        [InlineData(100)]
        public void PremiumUser_Money_Debe_Ser_Igual_A_Valor_Inicial_Si_Es_Menor_A_100(decimal money)
        {
            //Arrange
            //Fact
            decimal result = _resolverFactory.Resolve(UserTypes.Premium).CalculateUserMoneyAmount(money);
            //Assert
            Assert.Equal(money, result);
        }



    }
}
