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

        // 1.yol
        if (String.IsNullOrEmpty(_memoryCache.Get<string>("Time")))
        {
            _memoryCache.Set<string>("Time", DateTime.Now.ToString());

        }

        // 2.yol

        if(!_memoryCache.TryGetValue("Time", out string timeCache))
        {
            _memoryCache.Set<string>("Time", DateTime.Now.ToString());

        }


        return View();
    }

    public IActionResult DisplayTime()
    {
        _memoryCache.GetOrCreate<string>("Time", entry =>
        {
            return DateTime.Now.ToString();
        });

        ViewBag.Time = _memoryCache.Get<string>("Time");
        return View();
    }
}
