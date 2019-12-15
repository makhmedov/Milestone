
using AutoT.Interfaces;
using AutoT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoT.Services
{
    public class UserService
    {
        private readonly IUser _user;

        public UserService(IUser context)
        {
            _user = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _user.GetAll();
        }

        public async Task AddAndSave(User movie)
        {
            _user.Add(movie);
            await _user.Save();
        }

        public async Task DeleteUser(int id)
        {
            await _user.DeleteUser(id);
        }


        /* public bool checkUser2(int id)
         {
             if (id < 0)
             {
                 throw new System.ArgumentException("user cannot be null", "original");
             }
             else if (id == null)
             {
                 throw new System.ArgumentException("ID cannot be null", "original");
             }
             else
             {
                 return true;
             }
         }*/
    }
}