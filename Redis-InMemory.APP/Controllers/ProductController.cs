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

        //// 1.yol
        //if (String.IsNullOrEmpty(_memoryCache.Get<string>("Time")))
        //{
        //    _memoryCache.Set<string>("Time", DateTime.Now.ToString());

        //}

        // 2.yol

        // Cachelenecek olan datayı set ettiğimiz kısım.


        MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();


        // 1 dakika süreyle, 4 kez cache'deki dataya erişlebilirz ( 4 çünkü sliding expiration 15 saniyeye set)
        options.AbsoluteExpiration = DateTime.Now.AddSeconds(15);

        // Her 15 saniyede memory'yi yeniler. erişmez isek silinir.
       // options.SlidingExpiration = TimeSpan.FromSeconds(15);

        options.Priority = CacheItemPriority.High; // Time key üzerinden, memory'de data tutulurken priority'si belirlenir. 


        // delegate'ler metodları işaret eder ( 4 tane parametre alan bir metodu lambda ile yazdık. lambda kullanmasaydık method oluşturucaktık.

        options.RegisterPostEvictionCallback((key, value, reason, state) => {

            _memoryCache.Set("callback", $"{key}->{value} => reason: {reason}");
        });


        // memory'de, Time oluştuğu zaman, 20 saniyelik oluşacak
        _memoryCache.Set<string>("Time", DateTime.Now.ToString(), options);




        return View();
    }

    public IActionResult DisplayTime()
    {
        //_memoryCache.GetOrCreate<string>("Time", entry =>
        //{
        //    return DateTime.Now.ToString();
        //});

        _memoryCache.TryGetValue("Time", out string timeCache);
        _memoryCache.TryGetValue("callback", out string callback);
        ViewBag.Time = timeCache;

        ViewBag.callback = callback;
        ViewBag.Time = _memoryCache.Get<string>("Time");
        return View();
    }


    // Not: İlk olarak https://localhost:7199/product/ 'e gidip index oluşturmak gerekiyor.
    // ardından https://localhost:7199/product/displaytime 'a gidince 20 saniyelik süreyle cache'de tuttuğumuz datayı display ediyoruz.

}

/*
 
Absolute Expiration (Mutlak Süre Sonu):
 
Belirtilen kesin bir tarih veya süreden sonra önbellekteki veri otomatik olarak silinir.
Örnek: "Bu veri 30 dakika sonra silinsin."

-----------------


Sliding Expiration (Kayan Süre Sonu):

Veriye her erişildiğinde süre yenilenir.
Belirtilen süre boyunca erişim olmazsa veri silinir.
Örnek: "Son erişimden itibaren 10 dakika boyunca erişim olmazsa silinsin."


*/
