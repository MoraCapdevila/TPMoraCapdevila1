using TPMoraCapdevila1.Data.Entities;
using TPMoraCapdevila1.Data.Models;

namespace TPMoraCapdevila1.Services.Interfaces
{
    public interface ITodoItemService
    {
        TodoItem GetById(int id);
        IEnumerable<object> GetAll();
      
        int Create(TodoCreateDto newItemDTO);
        bool Update(int id, TodoCreateDto updatedItemDTO);
        bool Delete(int id);
    }
}
