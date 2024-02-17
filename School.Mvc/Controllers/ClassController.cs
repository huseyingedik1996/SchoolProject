using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using School.Mvc.Models.ClassModel;

namespace School.Mvc.Controllers
{
    public class ClassController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ClassController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5287/api/Classes/Classes/getall");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                try
                {
                    var values = JsonConvert.DeserializeObject<ApiClassListModel>(jsonData);
                    return View(values);
                }
                catch (JsonSerializationException ex)
                {
                    // Dönüşüm hatası
                    // Hatanın nedenini inceleyin veya hata iletisini kaydedin
                    // JSON formatını kontrol edin ve dönüşüm işlemini düzeltin
                    //return RedirectToAction("Error");
                    throw new Exception("JSON dönüşüm hatası", ex);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateClass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateClass(int a)
        {
            return View();
        }


    }
}
