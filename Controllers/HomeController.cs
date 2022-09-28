using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PreguntadORT_Chediex_Pascual.Models;

namespace PreguntadORT_Chediex_Pascual.Controllers;

public class HomeController : Controller
{
    private IWebHostEnvironment Environment;
    private readonly ILogger<HomeController> _logger;
    public HomeController(IWebHostEnvironment environment)
    {
        Environment = environment;
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
        ViewBag.Username = Juego.Username;
        ViewBag.PuntajeActual = Juego.PuntajeActual;

        ViewBag.RespuestasCorrectas = Juego.CantidadPreguntasCorrectas;

        if(Juego.ObtenerProximaPregunta() != null)
        {
            ViewBag.Foto = Juego.ObtenerProximaPregunta().Foto;
            ViewBag.Dificultad = Juego.ObtenerProximaPregunta().IdDificultad;
            ViewBag.Enunciado = Juego.ObtenerProximaPregunta().Enunciado;
            ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(Juego.ObtenerProximaPregunta().IdPregunta);
            return View("Juego");
        }
        else
        {
            DateTime dia = DateTime.Now;
            ScoreBoard puntaje = new ScoreBoard(Juego.Username, Juego.PuntajeActual, dia);
            BD.IsertarScoreboard(puntaje);
            return View("Fin");
        }
    }
    public IActionResult HighScores()
    {
        ViewBag.Score = BD.ObtenerScoreBoard();
        return View("HighScores");
    }
    public IActionResult ListaPreguntas()
    {
        //ViewBag.Lista = Juego.ListaPreguntas;
        ViewBag.Lista = BD.ObtenerPreguntas(-1,-1);
        return View();
    }
    public IActionResult VerificarRespuesta(int IdPregunta, int IdRespuesta,int IdDificultad)
    {
        string opcCorrecta = "";
        foreach(Respuestas resp in BD.ObtenerProximasRespuestas(IdPregunta))
        {
            if (resp.Correcta == true)
            {
                opcCorrecta = resp.Contenido;
            }
        }
        bool Resul = Juego.VerificarRespuestas(IdPregunta, IdRespuesta, IdDificultad);
        if(Resul == true)
        {
            ViewBag.Resultado = true;
        }
        else
        {
            ViewBag.Resultado = false;
            ViewBag.OpcCorrecta = opcCorrecta;
        }
        return View("Respuesta");
    }
    public IActionResult AgregarPreguntas(int IdPregunta, int IdDificultad, int IdCategoria, int IdRespuesta)
    {
        ViewBag.IdPregunta = IdPregunta;
        ViewBag.ListaCategoria = Juego.ObtenerCategorias();
        ViewBag.ListaDificultad = Juego.ObtenerDificultades();
        return View();
    }
    public IActionResult AgregarRespuestas(int IdPregunta)
    {
        ViewBag.IdPregunta = IdPregunta;
        return View();
    }
    [HttpPost] 
    public IActionResult  GuardarPregunta(int IdCategoria, int IdDificultad, string Enunciado, IFormFile Foto)
    {  
        if(Foto.Length > 0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\Imagenes\" + Foto.FileName;
            using( var stream = System.IO.File.Create(wwwRootLocal))
            {
                Foto.CopyToAsync(stream);
            }
        }
        Preguntas preg = new Preguntas(IdCategoria, IdDificultad, Enunciado, ("" + Foto.FileName));
        BD.AgregarPregunta(preg);
        return RedirectToAction("ListaPreguntas");
    }
    [HttpPost] 
    public IActionResult  GuardarRespuesta(int IdPregunta, string Contenido1, int Opcion1, int Correcta1 , string Contenido2, int Opcion2, int Correcta2, string Contenido3, int Opcion3, int Correcta3, string Contenido4, int Opcion4, int Correcta4)
    {


        Respuestas resp1 = new Respuestas(IdPregunta, Opcion1, Contenido1, false);
        Respuestas resp2 = new Respuestas(IdPregunta, Opcion2, Contenido2, false);
        Respuestas resp3 = new Respuestas(IdPregunta, Opcion3, Contenido3, false);
        Respuestas resp4 = new Respuestas(IdPregunta, Opcion4, Contenido4, false);

        if(Correcta1 == 1)
        {
            resp1 = new Respuestas(IdPregunta, Opcion1, Contenido1, true);
        }
        if(Correcta2 == 1)
        {
            resp2 = new Respuestas(IdPregunta, Opcion1, Contenido1, true);
        }
        if(Correcta3 == 1)
        {
            resp3 = new Respuestas(IdPregunta, Opcion1, Contenido1, true);
        }
        if(Correcta4 == 1)
        {
            resp4 = new Respuestas(IdPregunta, Opcion1, Contenido1, true);
        }

        BD.AgregarRespuesta(resp1);
        BD.AgregarRespuesta(resp2);
        BD.AgregarRespuesta(resp3);
        BD.AgregarRespuesta(resp4);
        
        return RedirectToAction("ListaPreguntas");
    }
    public IActionResult EliminarPregunta(int IdPregunta)
    {
        BD.EliminarPregunta(IdPregunta);
        return RedirectToAction("Listapreguntas");
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
