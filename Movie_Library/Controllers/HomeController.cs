using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Movie_Library.Data;
using Movie_Library.Models;
namespace Movie_Library.Controllers;
/* //////////////////////////////////////////////////////////////////////// */


/* //////////////////////////////////////////////////////////////////////// */



public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
/* /////////////////////////////// */
    public IActionResult Index()
    {
        return View();
    }
    
/* /////////////////////////////// */
    public IActionResult Privacy()
    {
        return View();
    } 
    
/* /////////////////////////////// */
    public IActionResult Movie()
    {
        List<MovieMod> movies = new List<MovieMod>();
        MovieDAO movieDAO = new MovieDAO();

        movies = movieDAO.FetchAll();
        
        return View("Movie", movies);
    }
    
/* /////////////////////////////// */
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
/* /////////////////////////////// */
    public IActionResult Create()
    {
        throw new NotImplementedException();
    }
    
/* /////////////////////////////// */
    public IActionResult Edit(string filmtitle)
    {
        throw new NotImplementedException();
    }
    
/* /////////////////////////////// */
    public IActionResult Details(string filmTitle)
    {
        MovieDAO movieDao = new MovieDAO();
        MovieMod movieMod = movieDao.FetchDetails(filmTitle);
        return View("Details", movieMod);
    }
    
/* /////////////////////////////// */
    public IActionResult Delete(string filmtitle)
    {
        throw new NotImplementedException();
    }
/* /////////////////////////////// */
}
