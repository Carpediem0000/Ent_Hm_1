using Ent_Hm_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ent_Hm_1
{
    internal class ToDoListService
    {
        private readonly AppDbContext _appDbContext;
        public ToDoListService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Methods
        public void AddCategory(string category)
        {
            _appDbContext.Categories.Add(new Category { Name = category });
            _appDbContext.SaveChanges();
        }
        public Category GetCategory(int id)
        {
            Category category = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
            return category;
        }
        public void UpdateCategory(Category category)
        {
            var item = _appDbContext.Categories.FirstOrDefault(p => p.Id == category.Id);
            if (item != null)
            {
                item.Name = category.Name;
                _appDbContext.SaveChanges();
            }
        }
        public void RemoveCategory(int id)
        {
            var item = _appDbContext.Categories.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                _appDbContext.Categories.Remove(item);
                _appDbContext.SaveChanges();
            }
        }

        public void AddTask(Models.Task task)
        {
            _appDbContext.Tasks.Add(task);
            _appDbContext.SaveChanges();
        }
        public Models.Task GetTask(int id)
        {
            Models.Task task = _appDbContext.Tasks.FirstOrDefault(t => t.Id == id);
            return task;
        }
        public void UpdateTask(Models.Task task)
        {
            var item = _appDbContext.Tasks.FirstOrDefault(p => p.Id == task.Id);
            if (item != null)
            {
                item.Description = task.Description;
                item.Date = task.Date;
                item.IsDone = task.IsDone;
                item.CategoryId = task.CategoryId;
                _appDbContext.SaveChanges();
            }
        }
        public void ChangeStatus(int id)
        {
            var item = _appDbContext.Tasks.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                item.IsDone = item.IsDone ? false : true;
                _appDbContext.SaveChanges();
            }
        }
        public void RemoveTask(int id)
        {
            var item = _appDbContext.Tasks.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                _appDbContext.Tasks.Remove(item);
                _appDbContext.SaveChanges();
            }
        }

        public List<Models.Task> GetTaskList()
        {
            var tasks = _appDbContext.Tasks.ToList();
            return tasks;
        }
        public List<Category> GetCategories()
        {
            var categories = _appDbContext.Categories.ToList();
            return categories;
        }
        public override string ToString()
        {
            string res = string.Empty;
            foreach (var category in _appDbContext.Categories.ToList())
            {
                res += $"\tId:{category.Id} {category.Name}\n-----------------------------------------------\n";
                foreach (var task in _appDbContext.Tasks.Where(t => t.CategoryId == category.Id).ToList())
                {
                    res += $"Id: {task.Id} {task.Description}";
                    res += task.IsDone ? " \u001b[32mВыполнено\u001b[0m\n" : " \u001b[31mНе Выполнено\u001b[0m\n";
                }
                res += "-----------------------------------------------\n";
            }
            return res;
        }
    }
}
