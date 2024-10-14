using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Redis_InMemory.APP.Controllers;
public class ProductController : Controller
{

    private readonly IMemoryCache _memoryCache;

    public ProductController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    public IActionResult Index()
    {

        _memoryCache.Set<string>("Time", DateTime.Now.ToString());

        return View();
    }

    public IActionResult DisplayTime()
    {
        ViewBag.Time = _memoryCache.Get<string>("Time");
        return View();
    }
}
