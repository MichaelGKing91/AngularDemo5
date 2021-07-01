using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteDonuts.Models
{
    public class DAL
    {
        public static IDbConnection db;
        public static Favorite AddUserFavorite(string newUsername, int newDonut)
        {
            Favorite fav = new Favorite { username = newUsername, donut = newDonut };
            db.Insert(fav);
            return fav;
        }

        // Get all favorites for a particular user
        public static List<Favorite> GetFavsByUser(string username)
        {
            // Old way - subject to SQL injection
            //db.Query($"select * from favorite where username = '{username}'");

            // New way - more secure
            return db.Query<Favorite>("select * from favorite where " +
                "username = @uname", new { uname = username }).ToList();
        }

        // Find out if a donut has been favorited by a particular user
        // We may not need this

        public static void RemoveUserFavorite(int theid)
        {
            Favorite fav = new Favorite() { id = theid };
            db.Delete(fav);
        }

        public static bool IsFavorite(string username, int donut)
        {
            List<Favorite> results = db.Query<Favorite>("select * from favorite where username = @uname and donut = @did",
                new { uname = username, did = donut }).ToList();
            if (results.Count == 0)
            {
                return false;
            }
            else
            {
               return true;
            }
        }

    }
}
