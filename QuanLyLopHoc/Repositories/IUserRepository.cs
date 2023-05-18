using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Repositories
{
    public interface IUserRepository
    {
        public Task<User> FindUserByEmail(string email);
        public Task<User> FindUserById(string id);
        public Task<ICollection<User>> FindListUserByName(string name);
        public Task<ICollection<User>> FindListUserByNameandEmail(string searchKey);
        public ICollection<User> FindListUser(string name);
        public ICollection<User> FindListUserbyEmail(string email);
        public Task Create( User user);
        public Task Update(User userinfo);

    }
}
