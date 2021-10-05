using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Servicies.Builder
{
    public interface IUserBuilder
    {
        User Build(UserDTO userDTO);
    }
}
