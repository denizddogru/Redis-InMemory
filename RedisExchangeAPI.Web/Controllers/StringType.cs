using IDistributedCacheRedisApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisExchangeAPI.Web.Controllers;
public class StringType : Controller
{
    private readonly RedisService _redisService;
    private readonly IDatabase db;
    public StringType(RedisService redisService)
    {
        _redisService = redisService;
        db = _redisService.GetDb(0);
    }


    // https://localhost:7010/stringtype
    public IActionResult Index()
    {
        db.StringSet("name", "Deniz Dogru");
        db.StringSet("visitor", 100);

        return View();
    }

    // https://localhost:7010/stringtype/display

    public IActionResult Display()
    {

        var redisValue = db.StringGet("name");

        db.StringIncrement("visitor", 1);

        if(redisValue.HasValue)
        {
            ViewBag.redisValue = redisValue.ToString();
        }

        return View();
    }
}
