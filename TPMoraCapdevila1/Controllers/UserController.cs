
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using System.Linq.Expressions;
using TPMoraCapdevila1.Data.Models;
using TPMoraCapdevila1.Entities;
using TPMoraCapdevila1.Services.Interfaces;

namespace TPMoraCapdevila1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers(); 
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id); 
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is missing");
            }

            //Cuando mappeo aca el dto no uso el id para que me lo cree solo y sea autoincremental con la bd
            var newUser = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Adress = userDto.Adress
            };

            _userService.CreateUser(newUser);


            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] UserDTO updateUserDto)
        {
            if (updateUserDto == null)
            {
                return BadRequest("Update data is missing");
            }

            var existingUser = _userService.GetUserById(userId);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            // Actualizar propiedades del usuario existente
            existingUser.Name = updateUserDto.Name;
            existingUser.Email = updateUserDto.Email;
            existingUser.Adress = updateUserDto.Adress;

            // Llamar al método UpdateUser del servicio para aplicar los cambios
            _userService.UpdateUser(userId, existingUser);

            return Ok("Usuario actualizacon con exito");
    
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Ok("Usuario eliminado con exito");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
