using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPMoraCapdevila1.Data.Entities;
using TPMoraCapdevila1.Data.Models;
using TPMoraCapdevila1.Services.Interfaces;

namespace TPMoraCapdevila1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var item = _todoItemService.GetById(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var items = _todoItemService.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create(TodoCreateDto newItemDTO)
        {
            try
            {
                // Llamar al servicio para crear un nuevo TodoItem
                int newItemId = _todoItemService.Create(newItemDTO);

                // Devolver una respuesta de éxito con el ID del nuevo TodoItem creado
                return Ok($"TodoItem creado con ID: {newItemId}");
            }
            catch (Exception ex)
            {
                // Devolver una respuesta de error en caso de excepción
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoCreateDto updatedItemDTO)
        {
            bool success = _todoItemService.Update(id, updatedItemDTO);
            if (!success)
                return NotFound();

            return Ok($"TodoItem con ID {id} actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool success = _todoItemService.Delete(id);
            if (!success)
                return NotFound();

            return Ok($"TodoItem con ID {id} eliminado correctamente");
        }



    }


    

    
}
