using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Enum;
using Sat.Recruitment.Servicies.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Servicies.Builder
{
    public class UserBuilder : IUserBuilder
    {
        private IUserMoneyResolverFactory _userMoneyFactory;
        public UserBuilder(IUserMoneyResolverFactory userMoneyFactory)
        {
            this._userMoneyFactory = userMoneyFactory;
        }
        User IUserBuilder.Build(UserDTO userDTO)
        {
            var typeUser = Enum.TryParse<UserTypes>(userDTO.UserType, out var res) ? res : UserTypes.Normal;
            return new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Address = userDTO.Address,
                Money = _userMoneyFactory.Resolve(typeUser).CalculateUserMoneyAmount(userDTO.Money),
                Phone = userDTO.Phone,
                UserType = userDTO.UserType

            };
        }
    }
}
