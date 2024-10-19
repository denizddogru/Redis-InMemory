using IDistributedCacheRedisApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

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

        cacheEntryOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(30);

        //await _distributedCache.SetStringAsync("surname","Dogru",  cacheEntryOptions);
        //await _distributedCache.SetStringAsync("isim", "Arzu", cacheEntryOptions);

        Product product = new Product { Id = 2, Name = "Test2", Price = 105};
        string jsonProduct = JsonConvert.SerializeObject(product);

        await _distributedCache.SetStringAsync("product:2", jsonProduct, cacheEntryOptions);



        return View();
    }

    public IActionResult DisplayTime()
    {
        //string name = _distributedCache.GetString("isim");

        string jsonProduct = _distributedCache.GetString("product:1");
        Product p = JsonConvert.DeserializeObject<Product>(jsonProduct);

        ViewBag.product = p;
        return View();
    }

    public IActionResult Remove()
    {
        _distributedCache.Remove("isim");

        return View();
    }
}
