using Sat.Recruitment.Core.Abstraction;
using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Enumerator;
using Sat.Recruitment.Core.Normalize;
using System;

namespace Sat.Recruitment.Core.Builder
{
    public class UserBuilder : IUserBuilder
    {
        private IUserMoneyResolverFactory _userMoneyFactory;
        private INormalize _normalize;
        public UserBuilder(IUserMoneyResolverFactory userMoneyFactory, INormalize normalize)
        {
            this._userMoneyFactory = userMoneyFactory;
            this._normalize = normalize;
        }
        User IUserBuilder.Build(UserDTO userDTO)
        {
            var typeUser = Enum.TryParse<UserTypes>(userDTO.UserType, out var res) ? res : UserTypes.Normal;
            return new User
            {
                Name = userDTO.Name,
                Email = _normalize.NormalizeEmail(userDTO.Email),
                Address = userDTO.Address,
                Money = _userMoneyFactory.Resolve(typeUser).CalculateUserMoneyAmount(userDTO.Money),
                Phone = userDTO.Phone,
                UserType = userDTO.UserType

            };
        }
    }
}
