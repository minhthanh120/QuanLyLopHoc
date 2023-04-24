﻿using Microsoft.EntityFrameworkCore;
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
        public async Task Create(string id, string email)
        {
            try
            {
                var user = new User();
                user.Id = id;
                user.Email = email;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
        public void Update(User userInfo)
        {
            try
            {
                var currentUser = _context.Find<User>(userInfo.Id);
                if (currentUser != null)
                {
                    currentUser = userInfo;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
