using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public interface IUserService
    {
        public Task<ICollection<User>> SearchByName(string name);
        public Task<ICollection<User>> SearchByNameandEmail(string searchKey);
        public ICollection<User> Search(string name);
        public Task CreateUserInfo(User user);
        public Task<User> GetUserbyId(string id);
        public Task Edit(User user);
    }
}
