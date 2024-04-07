using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.DataModels;
using SimpleCRUD.Interfaces;
using SimpleCRUD.ServiceModels;

namespace SimpleCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ResponseData<User> Get()
        {
            try
            {
                List<User> users = _userManager.GetUsers().ToList();
                return new ResponseData<User> { Status = 200, Message = "Users list", List = users };
            }
            catch (Exception ex)
            {
                return new ResponseData<User> { Status = 400, Message = ex.Message };
            }
        }

        [HttpGet("{id}")]
        public ResponseData<User> Get(int id)
        {
            try
            {
                User user = _userManager.GetUserDetail(id);
                return new ResponseData<User> { Status = 200, Message = "User details", Object = user };
            }
            catch (Exception ex)
            {
                return new ResponseData<User> { Status = 400, Message = ex.Message };
            }
        }

        [HttpPost]
        public Response Post([FromBody] UpdateUser user)
        {
            try
            {
                int ret = _userManager.AddUser(new User { Id = user.Id, Address = user.Address, Name = user.Name, RoleId = user.RoleId, StateId = user.StateId });
                if (ret == 1)
                {
                    return new ResponseData<User> { Status = 200, Message = "User added successfully" };
                }
                else
                {
                    return new ResponseData<User> { Status = 400, Message = "Failed to add user, please contact administrator" };
                }
            }
            catch (Exception ex)
            {
                return new ResponseData<User> { Status = 400, Message = ex.Message };
            }
        }

        [HttpPut]
        public Response Put([FromBody] UpdateUser user)
        {
            try
            {
                int ret = _userManager.UpdateUser(new User { Id = user.Id, Address = user.Address, Name = user.Name, RoleId = user.RoleId, StateId = user.StateId });
                if (ret == 1)
                {
                    return new ResponseData<User> { Status = 200, Message = "User updated successfully" };
                }
                else
                {
                    return new ResponseData<User> { Status = 400, Message = "Failed to update user, please contact administrator" };
                }
            }
            catch (Exception ex)
            {
                return new ResponseData<User> { Status = 400, Message = ex.Message };
            }
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            try
            {
                int ret = _userManager.DeleteUser(id);
                if (ret == 1)
                {
                    return new ResponseData<User> { Status = 200, Message = "User deleted successfully" };
                }
                else
                {
                    return new ResponseData<User> { Status = 400, Message = "Failed to delete user, please contact administrator" };
                }
            }
            catch (Exception ex)
            {
                return new ResponseData<User> { Status = 400, Message = ex.Message };
            }
        }

        [HttpGet, Route("GetStates")]
        public ResponseData<State> GetStates()
        {
            try
            {
                List<State> states = _userManager.GetStates().ToList();
                return new ResponseData<State> { Status = 200, Message = "State's list", List = states };
            }
            catch (Exception ex)
            {
                return new ResponseData<State> { Status = 400, Message = ex.Message };
            }
        }

        [HttpGet, Route("GetRoles")]
        public ResponseData<Role> GetRoles()
        {
            try
            {
                List<Role> roles = _userManager.GetRoles().ToList();
                return new ResponseData<Role> { Status = 200, Message = "Role's list", List = roles };
            }
            catch (Exception ex)
            {
                return new ResponseData<Role> { Status = 400, Message = ex.Message };
            }
        }
    }
}