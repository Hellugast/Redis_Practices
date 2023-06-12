using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        //[HttpGet]
        //public string GetName()
        //{
        //    if (_memoryCache.TryGetValue("Name", out string name))
        //    {
        //        return _memoryCache.Get<string>("Name");
        //    }
        //    return "Hatalı key değeri";

        //}

        //[HttpPost]
        //public void SetName([FromBody] string nameValue)
        //{
        //    _memoryCache.Set("Name", nameValue);

        //}

        ////[HttpGet("set/{name}")]
        ////public void GetName(string name)
        ////{
        ////    _memoryCache.Set("Name", name);

        ////}
        ///

        [HttpGet("setDate")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("Date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
        }

        [HttpGet("getDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("Date");
        }


    }
}
