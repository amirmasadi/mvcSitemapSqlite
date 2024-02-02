using Microsoft.AspNetCore.Mvc;
using mvcSitemapSqlite.Models;
using mvcSitemapSqlite.Repository;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace mvcSitemapSqlite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static readonly ISitemapNodeRepository Rep_Sitemap = new SitemapNodeRepository();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string xml = Rep_Sitemap.SetSitemapNodes(this.Url, System.Environment.CurrentDirectory + "sitemap.xml");

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
