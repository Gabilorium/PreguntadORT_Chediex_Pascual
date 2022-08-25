using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PreguntadORT_Chediex_Pascual.Models;

namespace PreguntadORT_Chediex_Pascual.Controllers;

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

    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.ListaCategoria = Juego.ObtenerCategorias();
        ViewBag.ListaDificultad = Juego.ObtenerDificultades();
        return View();
    }
    public IActionResult Comenzar(string Username, int IdDificultad, int IdCategoria)
    {
        Juego.InicializarJuego();
        Juego.CargarPartida(Username, IdCategoria, IdCategoria);
        return RedirectToAction("Jugar", "Home", new{IdDificultad = IdDificultad, IdCategoria = IdCategoria});
    }
    public IActionResult Jugar()
    {
        ViewBag.IdPregunta = Juego.ObtenerProximaPregunta();
        ViewBag.IdCategoria = Categorias.IdCategoria;
        ViewBag.IdDificultad = Dificultades.IdDificultad;
        if(Juego.ObtenerProximaPregunta() != null)
        {
            ViewBag.IdRespuesta = Juego.ObtenerProximasRespuestas(IdPregunta);
            return View("Juego");
        }
        else
        {
            return View("Fin");
        }
    }
    [HttpPost] 
    public IActionResult VerificarRespuesta(int IdPregunta, int IdRespuesta)
    {
        //Juego.VerificarRespuestas(IdPregunta, IdRespuesta);
        if(Juego.VerificarRespuestas(IdPregunta, IdRespuesta) = true)
        {
            ViewBag.Resultado = "Es correcta";
        }
        else
        {
            ViewBag.Resultado = "La respuesta es incorrecta, la respuesta correcta es: " + BD.ObtenerProximasRespuestas(IdPregunta);
        }
        return View("Respuesta");
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
