using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ent_Hm_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../../"))
                .AddJsonFile("appsettings.json")
                .Build();

            string ConnectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            using (var context = new AppDbContext(optionsBuilder.Options, config))
            {
                ToDoListService toDoListService = new(context);

                //toDoListService.AddCategory("Работа");
                //toDoListService.AddCategory("Учеба");
                //toDoListService.AddCategory("Домашние дела");

                //toDoListService.AddTask(new Models.Task { Description = "Задача 1", Date = DateTime.Today, IsDone = false, CategoryId = 1 });
                //toDoListService.AddTask(new Models.Task { Description = "Задача 2", Date = DateTime.Today, IsDone = true, CategoryId = 2 });
                //toDoListService.AddTask(new Models.Task { Description = "Задача 3", Date = DateTime.Today, IsDone = false, CategoryId = 1 });
                //toDoListService.AddTask(new Models.Task { Description = "Задача 4", Date = DateTime.Today, IsDone = false, CategoryId = 3 });

                Console.WriteLine(toDoListService);
            }
        }
    }
}
