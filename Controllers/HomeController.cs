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
        Juego.CargarPartida(Username, IdDificultad, IdCategoria);
        return RedirectToAction("Jugar", "Home", new{Username = Username, IdDificultad = IdDificultad, IdCategoria = IdCategoria});
    }
    public IActionResult Jugar()
    {
        //Preguntas pregunta = Juego.ObtenerProximaPregunta();
        //ViewBag.preg = Juego.ObtenerProximaPregunta();
        if(Juego.ObtenerProximaPregunta() != null)
        {
            ViewBag.Username = Juego.Username;
            ViewBag.PuntajeActual = Juego.PuntajeActual;
            ViewBag.Enunciado = Juego.ObtenerProximaPregunta().Enunciado;
            ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(Juego.ObtenerProximaPregunta().IdPregunta);
            return View("Juego");
        }
        else
        {
            return View("Fin");
        }
    }
    
    public IActionResult VerificarRespuesta(int IdPregunta, int IdRespuesta)
    {
        int Resul = Juego.VerificarRespuestas(IdPregunta, IdRespuesta);
        if(Resul == 1)
        {
            ViewBag.Resultado = "La respuesta es correcta";
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
