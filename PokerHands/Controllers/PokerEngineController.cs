using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PokerEngine;

using Newtonsoft.Json;

namespace PokerHands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokerEngineController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            Dealer dealer = new Dealer();
            PokerGame game = dealer.PlayHand();
            return JsonConvert.SerializeObject(game);
        }
    }
}