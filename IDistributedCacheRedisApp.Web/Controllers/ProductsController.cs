using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace IDistributedCacheRedisApp.Web.Controllers;
public class ProductsController : Controller
{
    private IDistributedCache _distributedCache;
    public ProductsController(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;

    }

    public async Task<IActionResult> Index()
    {
        DistributedCacheEntryOptions cacheEntryOptions = new DistributedCacheEntryOptions();

        cacheEntryOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(1);

        await _distributedCache.SetStringAsync("surname","Dogru",  cacheEntryOptions);
        await _distributedCache.SetStringAsync("isim", "Arzu", cacheEntryOptions);

        return View();
    }

    public IActionResult DisplayTime()
    {
        string name = _distributedCache.GetString("isim");

        return View();
    }

    public IActionResult Remove()
    {
        _distributedCache.Remove("isim");

        return View();
    }
}
