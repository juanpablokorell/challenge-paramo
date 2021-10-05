using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Interfaces;
using Sat.Recruitment.Core.Normalize;
using System.Threading.Tasks;

namespace Sat.Recruitment.Core.Servicies
{
    public class UserServicies : IUserServicies
    {
        private readonly IUserFileRepository _userFileRepository;
        private readonly INormalize _normalize;

        public UserServicies(IUserFileRepository userFileRepository, INormalize normalize)
        {
            _userFileRepository = userFileRepository;
            _normalize = normalize;
        }
        public async Task AddUser(User user)
        {
            await _userFileRepository.AddUser(user);
        }

        public async Task<bool> ExistUser(User user)
        {
            return await _userFileRepository.ExistUser(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userFileRepository.FindByEmailAsync(_normalize.NormalizeEmail(email));
        }
    }
}
