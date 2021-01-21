using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VotingDataInterface;
using VotingWeb.Models;

namespace VotingWeb.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var proxy = ServiceProxy.Create<IVotingData>(new Uri("fabric:/ContainerizedFabricMesh/VotingData"));

                var result = await proxy.Echo(nameof(HomeController));

                TempData["ReplyMessage"] = result;

                Log.Information("GetReplyFrom wurde erfolgreich aufgerufen");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Fehler beim Aufruf der GetReployFrom Methode");

                TempData["ReplyMessage"] = ex.Message;
            }

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
    }
}
