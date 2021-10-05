using Sat.Recruitment.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Core.Interfaces
{
    public interface IUserServicies
    {
        Task AddUser(User user);

        Task<User> FindByEmailAsync(string email);
        Task<Boolean> ExistUser(User user);


    }
}
