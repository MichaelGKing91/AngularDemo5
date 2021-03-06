using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewCardDemo.Controllers
{
    [Route("card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        [HttpGet("newdeck")]
        public async Task<Object> GetNewDeck()
        {
            // We could just return the Json object and ignore all the anonymous stuff
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            var response = await client.GetAsync("/api/deck/new/shuffle/?deck_count=1");
            string json = await response.Content.ReadAsStringAsync();
            var definition = new { deck_id = "" }; // This is the cookie cutter for what we want out of the JSON object
            var card_info = JsonConvert.DeserializeAnonymousType(json, definition); // This assists the cookie cutter
            return card_info;
        }

        [HttpGet("gethand/{id}")]
        public async Task<string> GetHand(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            var response = await client.GetAsync($"/api/deck/{id}/draw/?count=5");
            string json = await response.Content.ReadAsStringAsync();
            return json;

        }
    }
}
