using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using TPMoraCapdevila1.Data.Context;
using TPMoraCapdevila1.Entities;
using TPMoraCapdevila1.Services.Interfaces;


namespace TPMoraCapdevila1.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly TodoContext _todoContext;

        public UserService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public IEnumerable<object> GetAllUsers()
        {
            var users = _todoContext.Users
                .Select(u => new
                {
                    u.UserId,
                    u.Name,
                    u.Email,
                    u.Adress
                })
                .ToList();

            return users;
        }

        public User GetUserById(int id)
        {
            return _todoContext.Users
                .Include(u => u.TodoItems) 
                .FirstOrDefault(u => u.UserId == id);
        }

        public void CreateUser(User user)
        {
            _todoContext.Users.Add(user);
            _todoContext.SaveChanges();

   
        }

        public void UpdateUser(int userId, User updatedUser)
        {
            var existingUser = _todoContext.Users.FirstOrDefault(u => u.UserId == userId);

            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                existingUser.Adress = updatedUser.Adress;

                _todoContext.SaveChanges();
            }
            
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _todoContext.Users.FirstOrDefault(u => u.UserId == userId);

            if (userToDelete == null)
            {
                throw new NotFoundException($"User with ID {userId} not found");
            }

            _todoContext.Users.Remove(userToDelete);
            _todoContext.SaveChanges();
        }

    }
    
}
