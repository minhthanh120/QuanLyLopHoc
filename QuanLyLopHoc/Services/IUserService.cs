using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public interface IUserService
    {
        public Task<ICollection<User>> SearchByName(string name);
        public ICollection<User> Search(string name);
        public Task CreateUserInfo(string id, string email);
        public Task<User> GetUserbyId(string id);
        public void Edit(User user);
    }
}
