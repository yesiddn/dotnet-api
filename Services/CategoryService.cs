using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Services;

public class CategoryService : ICategoryService
{
  private readonly TasksContext _context;

  public CategoryService(TasksContext context) {
    _context = context;
  }

  public IEnumerable<Models.Category> GetCategories() {
    return _context.Categories; // tambien se puede hacer un .ToList()
  }

  // para volver asincrono el metodo, se le agrega async y se cambia el tipo de retorno a Task
  public async Task SaveCategory(Models.Category category) {
    _context.Categories.Add(category);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateCategory(Guid id, Models.Category category) {
    var categoryToUpdate = _context.Categories.Find(id);
    
    if (categoryToUpdate != null) {
      categoryToUpdate.Name = category.Name;
      categoryToUpdate.Description = category.Description;
      categoryToUpdate.Difficulty = category.Difficulty;

      await _context.SaveChangesAsync();
    }
  }

  public async Task DeleteCategory(Guid id) {
    var categoryToDelete = _context.Categories.Find(id);

    if (categoryToDelete != null) {
      _context.Categories.Remove(categoryToDelete);
      await _context.SaveChangesAsync();
    }
  }
}

public interface ICategoryService {
  IEnumerable<Models.Category> GetCategories();
  Task SaveCategory(Models.Category category);
  Task UpdateCategory(Guid id, Models.Category category);
  Task DeleteCategory(Guid id);
}