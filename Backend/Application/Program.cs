using Application.Services;
using EntityFramework.Data;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

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
