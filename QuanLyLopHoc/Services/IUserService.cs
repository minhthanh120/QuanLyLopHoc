using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Services
{
    public interface IUserService
    {
        public Task<ICollection<User>> SearchByName(string name);
        public Task CreateUserInfo(string id, string email);
    }
}
