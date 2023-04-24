using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Repositories
{
    public interface IUserRepository
    {
        public Task<User> FindUserByEmail(string email);
        public Task<User> FindUserById(string id);
        public Task<ICollection<User>> FindListUserByName(string name);
        public ICollection<User> FindListUser(string name);
        public Task Create(string id, string email);
        public void Update(User userinfo);

    }
}
