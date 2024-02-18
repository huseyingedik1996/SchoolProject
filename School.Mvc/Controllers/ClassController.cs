using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using School.Mvc.Models.ClassModel;
using System.Text;

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
        public async Task<IActionResult> CreateClass(ClassCreateModel createModel)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createModel);
			StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5287/api/Classes/Classes/create", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5287/api/Classes/{id}/delete");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }
  
		}

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5287/api/Classes/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ApiClassUpdateModel>(jsonData);
                return View(value);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update(ApiClassUpdateModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model.Data);
            StringContent stringContent = new(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("http://localhost:5287/api/Classes/Classes/update/", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }


    }
}
