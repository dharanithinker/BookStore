using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Contracts
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
