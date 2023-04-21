using practicaShell.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace practicaShell.Services
{
    public static class CoffeService
    {
        static SQLiteAsyncConnection db;

        static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            {
                //var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
                db = new SQLiteAsyncConnection(databasePath);

                await db.CreateTableAsync<Coffee>();
            }
        }

        public static async Task AddCoffe(string name, string roaster)
        {
            await Init();
            var image = "https://i.ibb.co/VNjKrpG/coffe-Image.jpg";
            var coffe = new Coffee
            {
                Name = name,
                Roaster = roaster,
                Image = image
            };

            var id = await db.InsertAsync(coffe);
        }

        public static async Task RemoveCoffe(int id)
        {
            await Init();
            await db.DeleteAsync<Coffee>(id);
        }

        public static async Task<IEnumerable<Coffee>> GetCoffe()
        {
            await Init();
            
            var coffees = await db.Table<Coffee>().ToListAsync();
            return coffees;
        }
    }
}
