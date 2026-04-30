namespace ToDoList.Models
{
    public static class ToDoItemsRepo
    {
        private static List<ToDoItem> _toDoItems = [
            new ToDoItem { Id = 1, Name = "Task 1", },
            new ToDoItem { Id = 2, Name = "Task 2", },
            new ToDoItem { Id = 3, Name = "Task 3", },
            new ToDoItem { Id = 4, Name = "Task 4", },
            ];

        public static void AddTask(ToDoItem task)
        {
            if (_toDoItems.Count > 0)
            {
                var maxId = _toDoItems.Max(s => s.Id);
                task.Id = maxId + 1;
                _toDoItems.Add(task);
            }
            else
            {
                task.Id = 1;
                _toDoItems.Add(task);
            }

        }

        public static List<ToDoItem> GetTasks()
        {
            return _toDoItems
                .OrderBy(i => i.IsCompleted)
                .ThenByDescending(i => i.Id)
                .ToList();
        }

        public static ToDoItem? GetTaskById(int id)
        {
            var task = _toDoItems.FirstOrDefault(s => s.Id == id);
            if (task != null)
            {
                return new ToDoItem
                {
                    Id = task.Id,
                    Name = task.Name
                };
            }

            return null;
        }

        public static void UpdateTask(int taskId, ToDoItem task)
        {
            if (taskId != task.Id) return;

            var taskToUpdate = _toDoItems.FirstOrDefault(s => s.Id == taskId);
            if (taskToUpdate != null)
            {
                taskToUpdate.Name = task.Name;
            }
        }

        public static void DeleteTask(int itemId)
        {
            var task = _toDoItems.FirstOrDefault(s => s.Id == itemId);
            if (task != null)
            {
                _toDoItems.Remove(task);
            }
        }

        public static List<ToDoItem> SearchTasks(string taskFilter)
        {
            return _toDoItems.Where(s => s.Name.Contains(taskFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
