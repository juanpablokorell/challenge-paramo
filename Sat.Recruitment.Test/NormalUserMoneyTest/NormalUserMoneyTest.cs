using Sat.Recruitment.Core.Abstraction;
using Sat.Recruitment.Core.Enumerator;
using Sat.Recruitment.Core.Factories;
using System;
using Xunit;

namespace Sat.Recruitment.Test.NormalUserMoneyTest
{
    public class NormalUserMoneyTest
    {
        IUserMoneyResolverFactory _resolverFactory;

        public NormalUserMoneyTest()
        {
            _resolverFactory = new UserMoneyResolverFactory();
        }

        [Fact]
        public void NormalUser_Money_Debe_Ser_12_Porciento_Mas_Si_Monto_Es_Mayor_100()
        {
            //Arrange
            decimal money = 101;
            //Fact
            decimal result = _resolverFactory.Resolve(UserTypes.Normal).CalculateUserMoneyAmount(money);

            //Asert
            Assert.Equal(Convert.ToDecimal(113.12), result);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(50)]
        [InlineData(11)]
        public void NormalUser_Money_Debe_Ser_8_Porciento_Superior_Si_Monto_Inicial_Es_Menor_Igual_A_100_Y_Mayor_a_10(decimal money)
        {
            //Arrange
            decimal expected = money + (money * Convert.ToDecimal(0.8));

            //Fact
            decimal result = _resolverFactory.Resolve(UserTypes.Normal).CalculateUserMoneyAmount(money);

            //Asert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void NormalUser_Money_Debe_Ser_Igual_Si_Es_Menor_Igual_A_10(decimal money)
        {
            //Arrange
            //Fact
            decimal result = _resolverFactory.Resolve(UserTypes.Normal).CalculateUserMoneyAmount(money);

            //Asert
            Assert.Equal(money, result);
        }

    }
}
