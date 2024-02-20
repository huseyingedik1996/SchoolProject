using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Mvc.Models.ClassModel;
using School.Mvc.Models.StudentModel;
using System.Net.Http;

namespace School.Mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StudentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5287/api/Student/Students/JoinGetall");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                try
                {
                    var values = JsonConvert.DeserializeObject<List<ApiStudentListModel>>(jsonData);
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
    }
}
