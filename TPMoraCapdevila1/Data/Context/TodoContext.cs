using Microsoft.EntityFrameworkCore;
using TPMoraCapdevila1.Data.Entities;
using TPMoraCapdevila1.Entities;

namespace TPMoraCapdevila1.Data.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> Users { get; set; }

        public TodoContext(DbContextOptions<TodoContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User //creo nuevos usuario
                {
                    UserId = 1,
                    Name = "Mora",
                    Email = "moracapdevila@gmail.com",
                    Adress = "Pellegrini 1876"
                },
                new User
                {
                    UserId = 2,
                    Name = "Juana",
                    Email = "juanita@gmail.com",
                    Adress = "Dorrego 1515"
                });
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem //creo nuevos items
                {
                    IdTodoItem = 1,
                    Title = "Ir al super",
                    Description = "Comprar milanesas, tomate y papas",
                    UserId = 1
                },
                new TodoItem
                {
                    IdTodoItem = 2,
                    Title = "Ir a la libreria",
                    Description = "Comprar cuadernillo y birome negra",
                    UserId = 2
                });

            //planteo la cardinalidad que un usuario puede tener una o muchas tareas
            //pero que una tarea solo está asignado a un unico usuario
            modelBuilder.Entity<TodoItem>()
                   .HasOne(u => u.User)
                   .WithMany(i => i.TodoItems)
                   .HasForeignKey(x => x.UserId); //la clave foranea para la union de ambas entidades es el id del usuario

            //base.OnModelCreating(modelBuilder);
        }
    }
}
