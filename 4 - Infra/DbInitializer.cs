using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurotecTaskBackApi.Infra
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Tasks.Any())
            {
                context.Tasks.AddRange(
                    new Entities.Task
                    {
                        Title = "Task 1",
                        Description = "Teste",
                        Status = (int)Entities.TaskStatus.Pending,
                        CreatedDate = DateTime.UtcNow,
                        IsCompleted = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
