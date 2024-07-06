using EntityFramework.Data;
using EntityFramework.Models;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext db = new AppDbContext())
            {
                List<Nation> riders = db.Nations.ToList();
            }
        }
    }
}
