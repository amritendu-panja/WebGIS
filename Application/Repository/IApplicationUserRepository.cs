﻿using Common.Entities;
using System.Linq.Expressions;

namespace Application.Repository
{
    public interface IApplicationUserRepository:IRepository<ApplicationUser>
    {
        bool IsEmailExists(string email);
        bool IsUsernameExists(string username);
        IQueryable<ApplicationUser> FindWithDetails(Expression<Func<ApplicationUser, bool>> expression);
    }
}
