using QuanLyLopHoc.Models.Entities;
using QuanLyLopHoc.Repositories;

namespace QuanLyLopHoc.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ICollection<User>> SearchByName(string name)
        {
            return await _userRepository.FindListUserByName(name);
        }
        public async Task CreateUserInfo(string id, string email)
        {
            await _userRepository.Create(id, email);
        }
    }
}
