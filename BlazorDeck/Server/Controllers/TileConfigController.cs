using BlazorDeck.Server.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDeck.Server.Controllers
{
    [Route("api/TileConfig")]
    [ApiController]
    public class TileConfigController : Controller
    {
        private readonly TileConfigManager tileConfigManager;

        public TileConfigController(TileConfigManager tileConfigManager)
        {
            this.tileConfigManager = tileConfigManager;
        }
        // GET: TileConfigController
        public ActionResult Index()
        {
            return Ok(tileConfigManager.GetPages());
        }
    }
}
