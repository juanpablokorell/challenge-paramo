using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Entities;

namespace Sat.Recruitment.Core.Builder
{
    public interface IUserBuilder
    {
        User Build(UserDTO userDTO);
    }
}
