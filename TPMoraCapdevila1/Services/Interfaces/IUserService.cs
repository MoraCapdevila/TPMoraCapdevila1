using TPMoraCapdevila1.Entities;
using TPMoraCapdevila1.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TPMoraCapdevila1.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<object> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(int userId, User user);
        void DeleteUser(int userId);

    }
}
