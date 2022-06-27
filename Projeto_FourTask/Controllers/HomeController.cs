
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto_FourTask.Areas.Identity.Data;
using Projeto_FourTask.Models;
using System.Diagnostics;

namespace Projeto_FourTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProjetoFourTaskContext _context;
        private UserManager<Usuario> _userManager;

        public HomeController(ILogger<HomeController> logger,
                              ProjetoFourTaskContext context,
                              UserManager<Usuario> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        
        public IActionResult Index()
        {
            Usuario usuarioLogado = _context.Usuarios.Find(_userManager.GetUserId(User));
            return View(usuarioLogado);
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