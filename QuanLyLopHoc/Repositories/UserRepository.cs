using Microsoft.EntityFrameworkCore;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.Entities;

namespace QuanLyLopHoc.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SMContext _context;
        private readonly ILogger _logger;
        public UserRepository(SMContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<ICollection<User>> FindListUserByName(string name)
        {
            try
            {
                //var listUser = await _context.Users.FindAsync(c=>(c.LastName.ToLower() +c.FirstName.ToLower()).Contains(name.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }
        public ICollection<User> FindListUser(string name)
        {
            try
            {
                name = name.ToLower();
                var listUser = _context.Users.Where(c => (c.FirstName.ToLower() + " " + c.LastName.ToLower()).Contains(name)).ToList();
                return listUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }

        public async Task<User> FindUserByEmail(string email)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.Email == email);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }

        public ICollection<User> FindListUserbyEmail(string email)
        {
            try
            {
                var result = _context.Users.Where(c=>c.Email.Contains(email)).ToList();
                if(result== null)
                {
                    result = new List<User>();
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }

        public async Task<User> FindUserById(string id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
                return user;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }
        public async Task Create(User userInfo)
        {
            try
            {
                var currentUser = _context.Find<User>(userInfo.Id);
                if (currentUser == null)
                {
                    currentUser = new User();
                    currentUser.Id = userInfo.Id;
                    currentUser.Avatar = userInfo.Avatar;
                    currentUser.School = userInfo.School;
                    currentUser.Class = userInfo.Class;
                    currentUser.City = userInfo.City;
                    currentUser.About = userInfo.About;
                    currentUser.BirthDay = userInfo.BirthDay;
                    currentUser.Gender = userInfo.Gender;
                    currentUser.LastName = userInfo.LastName;
                    currentUser.FirstName = userInfo.FirstName;
                    currentUser.Email = userInfo.Email;
                    _context.Add(currentUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
        public async Task Update(User userInfo)
        {
            try
            {
                var currentUser = _context.Find<User>(userInfo.Id);
                if (currentUser != null)
                {
                    currentUser.Avatar = userInfo.Avatar;
                    currentUser.School = userInfo.School;
                    currentUser.Class = userInfo.Class;
                    currentUser.City = userInfo.City;
                    currentUser.About = userInfo.About;
                    currentUser.BirthDay = userInfo.BirthDay;
                    currentUser.Gender = userInfo.Gender;
                    currentUser.LastName = userInfo.LastName;
                    currentUser.FirstName = userInfo.FirstName;
                    //currentUser. = userInfo.Avatar;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }

        public async Task<ICollection<User>> FindListUserByNameandEmail(string searchKey)
        {
            try
            {
                searchKey = searchKey.ToLower();
                var listUser = await _context.Users.Where(c => (c.FirstName.ToLower() + " " + c.LastName.ToLower()).Contains(searchKey)|| c.Email.Contains(searchKey)).ToListAsync();
                return listUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }
    }
}
