using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infrastructure.Repository
{
    public class UserFileRepository : IUserFileRepository
    {
        string _path = Directory.GetCurrentDirectory() + "\\Files\\Users.txt";

        public Task AddUser(User user)
        {
            StringBuilder userSb = new StringBuilder();
            userSb.AppendLine();
            userSb.Append(user.Name).Append(",");
            userSb.Append(user.Email).Append(",");
            userSb.Append(user.Phone).Append(",");
            userSb.Append(user.Address).Append(",");
            userSb.Append(user.UserType).Append(",");
            userSb.Append(user.Money);

            File.AppendAllText(_path, userSb.ToString());
            return Task.CompletedTask;
        }

        public async Task<bool> ExistUser(User user)
        {
            var users = await ReadUsersFromFile();
            User userF = users.FirstOrDefault(x => x.Email == user.Email);
            return (userF == null ? false : true);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var users = await ReadUsersFromFile();
            User user = users.FirstOrDefault(x => x.Email == email);
            return user;
        }

        private async Task<List<User>> ReadUsersFromFile()
        {
            List<User> users = new List<User>();
            using (FileStream fileStream = new FileStream(_path, FileMode.Open))
            {
                StreamReader reader = new StreamReader(fileStream);
                while (reader.Peek() >= 0)
                {
                    var line = await reader.ReadLineAsync();
                    var user = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString()),
                    };
                    users.Add(user);
                }
            }
            return users;
        }

    }
}
