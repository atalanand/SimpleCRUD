using Microsoft.EntityFrameworkCore;
using SimpleCRUD.DataModels;
using SimpleCRUD.Interfaces;

namespace SimpleCRUD.DAL
{
    public class UserDAL : IUserManager
    {
        private SimpleCrudContext _context;
        public UserDAL(SimpleCrudContext context)
        {
            _context = context;
        }

        IEnumerable<User> IUserManager.GetUsers()
        {
            try
            {
                return _context.Users.Include(r => r.Role).Include(s => s.State)?.ToList().OrderBy(o => o.Id);
            }
            catch
            {
                throw;
            }
        }
        User IUserManager.GetUserDetail(int id)
        {
            try
            {
                return _context.Users.First(x=>x.Id == id);
            }
            catch
            {
                throw;
            }
        }

        int IUserManager.AddUser(User user)
        {
            try
            {
                user.UpdatedDate = DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        int IUserManager.UpdateUser(User user)
        {
            try
            {
                user.UpdatedDate = DateTime.Now;
                _context.Entry(user).State = EntityState.Modified; 
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        int IUserManager.DeleteUser(int id)
        {
            try
            {
                User user = _context.Users.Find(id);
                _context.Users.Remove(user);
                _context.SaveChanges() ; 
                return 1;
            }
            catch
            {
                throw;
            }
        }

        List<State> IUserManager.GetStates()
        {
            try
            {
                return (
                    from state 
                    in _context.States 
                    select state).ToList();
            }
            catch
            {
                throw;
            }
        }

        List<Role> IUserManager.GetRoles()
        {
            try
            {
                return (
                    from role
                    in _context.Roles
                    select role).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
