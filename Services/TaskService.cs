using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Services;

public class TaskService
{
  private readonly TasksContext _context;

  public TaskService(TasksContext context)
  {
    _context = context;
  }

  public async Task<List<Models.Task>> GetTasks()
  {
    return await _context.Tasks.ToListAsync();
  }

  public async Task<Models.Task> CreateTask(Models.Task task)
  {
    _context.Tasks.Add(task);
    await _context.SaveChangesAsync();
    return task;
  }

  public async Task UpdateTask(Guid id, Models.Task task)
  {
    var taskToUpdate = await _context.Tasks.FindAsync(id);
    if (taskToUpdate != null)
    {
      taskToUpdate.Title = task.Title;
      taskToUpdate.Description = task.Description;
      taskToUpdate.IsComplete = task.IsComplete;
      taskToUpdate.Priority = task.Priority;
      taskToUpdate.CreatedAt = task.CreatedAt;

      await _context.SaveChangesAsync();
    }
  }

  public async Task DeleteTask(Guid id)
  {
    var task = await _context.Tasks.FindAsync(id);
    if (task != null)
    {
      _context.Tasks.Remove(task);
      await _context.SaveChangesAsync();
    }
  }
}

public interface ITaskService
{
  Task<List<Models.Task>> GetTasks();
  Task<Models.Task> CreateTask(Models.Task task);
  Task UpdateTask(Guid id, Models.Task task);
  Task DeleteTask(Guid id);
}