using FavoriteDonuts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteDonuts.Controllers
{
    [Route("favorite")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        // Possible URLs
        //    /favorite/add?username=mikeking&donut=5 <--use this one
        //    /favorite/add/mikeking/5
        //    /favorite/add/mikeking&donut=5
        // Add user favorite
        [HttpPost("add")]
        public bool AddUserFavorite(string username, int donut)
        {
            DAL.AddUserFavorite(username, donut);
            return true;
        }

        // Get Favorites by user
        //   /favorite/getfavs/mikeking
        [HttpGet("getfavs/{username}")]
        public List<Favorite> GetFavsByUser(string username)
        {
            return DAL.GetFavsByUser(username);
        }

        // Remove user favorite
        [HttpDelete("remove/{id}")]
        public bool RemoveUserFavorite(int id)
        {
            DAL.RemoveUserFavorite(id);
            return true;
        }

        [HttpGet("isfav")]
        public bool isFavorite(string username, int donut)
        {
            return DAL.IsFavorite(username, donut);
        }
    }
}
