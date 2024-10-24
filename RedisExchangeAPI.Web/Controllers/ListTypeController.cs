﻿using IDistributedCacheRedisApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisExchangeAPI.Web.Controllers;
public class ListTypeController : Controller
{

    private readonly RedisService _redisService;
    private readonly IDatabase db;
    private string listKey = "names";
    public ListTypeController(RedisService redisService)
    {
        _redisService = redisService;
        db = _redisService.GetDb(1);
    }
    public IActionResult Index()
    {
        List<string> namesList = new List<string>();

        if(db.KeyExists(listKey))
        {
            db.ListRange(listKey).ToList().ForEach(x =>
            {
                namesList.Add(x.ToString());
            });
        }
        return View(namesList);
    }

    [HttpPost]
    public IActionResult Add(string name)
    {

        db.ListRightPush(listKey, name);


        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult DeleteItem(string name)
    {
        db.ListRemoveAsync(listKey, name).Wait();

        return RedirectToAction("Index");
    }
}
