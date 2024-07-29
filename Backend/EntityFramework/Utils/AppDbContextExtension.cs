using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Utils
{
    public static class AppDbContextExtension
    {
        public static void InsertChunk<T>(AppDbContext context, DbSet<T> dbSet, List<T> entities) where T : class 
        {
            int count = 0;
            foreach (T entity in entities)
            {
                dbSet.Add(entity);
                count++;
                if (count % 500 == 0 || count == entities.Count)
                {
                    context.SaveChanges();
                }
            }
        }
    }
}
