using SimpleCRUD.DataModels;

namespace SimpleCRUD.Interfaces
{
    public interface IUserManager
    {
        IEnumerable<User> GetUsers();
        User GetUserDetail(int id);
        int AddUser(User user);
        int UpdateUser(User user);
        int DeleteUser(int id);
        List<State> GetStates();
        List<Role> GetRoles();
    }
}
