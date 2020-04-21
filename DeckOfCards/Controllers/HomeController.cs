using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DeckOfCards.Models;
using System.Net.Http;
using DeckOfCards.Models;
using Microsoft.Extensions.Configuration;

namespace DeckOfCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Deck()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");

            var response = await client.GetAsync("api/deck/new/shuffle/?deck_count=1");


            var deck = await response.Content.ReadAsAsync<Deck>();

            return View(deck);
        }

        public async Task<IActionResult> Cards(string deckId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");

            var response = await client.GetAsync("api/deck/new/shuffle/?deck_count=1");

            var deck = await response.Content.ReadAsAsync<Deck>();

            //var response = await client.GetAsync($"api/deck/{deckId}/draw/?count=5");
            response = await client.GetAsync($"api/deck/{deck.Deck_Id}/draw/?count=5");

            var cards = await response.Content.ReadAsAsync<CardList>();

            return View(cards);
        }
    }
}
