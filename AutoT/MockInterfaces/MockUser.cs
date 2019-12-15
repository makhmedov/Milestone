

using AutoT.Data;
using AutoT.Interfaces;
using AutoT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AutoT.MockInterfaces
{
    public class MockUser : IUser
    {
        private readonly ApplicationDbContext _context;

        public MockUser(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

        public Task DeleteUser(int id)
        {
            var var = _context.User.FindAsync(id);
            _context.User.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public Task<List<User>> GetAll()
        {
            return _context.User.ToListAsync();
        }

        public Task<List<User>> GetUsers(Expression<Func<User, bool>> predicate)
        {
            return _context.User.Where(predicate).ToListAsync();
        }

        public bool IsEntityExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}