using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TPMoraCapdevila1.Data.Context;
using TPMoraCapdevila1.Data.Entities;
using TPMoraCapdevila1.Data.Models;
using TPMoraCapdevila1.Services.Interfaces;

namespace TPMoraCapdevila1.Services.Implementation
{
    public class TodoItemService : ITodoItemService
    {
        private readonly TodoContext _context;
       

        public TodoItemService(TodoContext context)
        {
            _context = context;
           
        }

        public TodoItem GetById(int id)
        {

            var todoItem = _context.TodoItems
              .Where(t => t.IdTodoItem == id)
              .Include(t => t.User) // Me trae los datos del usuario que lo tiene asignado
              .FirstOrDefault();

            return todoItem;

        }

        public IEnumerable<object> GetAll()
        {
         
                var items = _context.TodoItems
                    .Select(t => new
                    {
                        t.IdTodoItem,
                        t.Title,
                        t.Description,
                        UserId = t.UserId // Me trae el UserId del usuario que lo tiene asigando
                    })
                    .ToList();

                return items;
           
        }

        public int Create(TodoCreateDto newItemDTO)
        {
            try
            {
                // Crear una nueva instancia de TodoItem y asignar los valores del DTO
                var newItem = new TodoItem
                {
                    Title = newItemDTO.Title,
                    Description = newItemDTO.Description,
                    UserId = newItemDTO.UserId
                };

                // Agregar el nuevo TodoItem a la base de datos
                _context.TodoItems.Add(newItem);
                _context.SaveChanges();

                // Devolver el ID del nuevo TodoItem creado
                return newItem.IdTodoItem;
            }
            catch (Exception ex)
            {
                // Manejar cualquier error y lanzar una excepción
                throw new Exception("Error al crear el nuevo TodoItem", ex);
            }
        }

        public bool Update(int id, TodoCreateDto updatedItemDTO)
        {
            var existingItem = _context.TodoItems.Find(id);
            if (existingItem == null)
                return false;

            existingItem.Title = updatedItemDTO.Title;
            existingItem.Description = updatedItemDTO.Description;

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var existingItem = _context.TodoItems.Find(id);
            if (existingItem == null)
                return false;

            _context.TodoItems.Remove(existingItem);
            _context.SaveChanges();

            return true;
        }


    }
}
