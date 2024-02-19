using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Mvc.Models.ClasshasMajorModel;
using School.Mvc.Models.ClassModel;
using School.Mvc.Models.MajorModel;
using System.Text;

namespace School.Mvc.Controllers
{
    public class ClassMajorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClassMajorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5287/api/MajorhasClasses/MajorhasClasses/getallef");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ClasshasMajorListModel>>(jsonData);
                return View(values);
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> CreateClassMajor()
        {
            //Major class'ına ait tüm verileri ViewBag yoluyla taşıyoruz
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage = await client1.GetAsync("http://localhost:5287/api/Majors/Major/getall");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ApiMajorListModel>(jsonData);
            ViewBag.Major = values.Data;


            //Major class'ına ait tüm verileri ViewBag yoluyla taşıyoruz
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5287/api/Classes/Classes/getall");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<ApiClassListModel>(jsonData2);

            ViewBag.Class = values2.Data;
            

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClassMajor(ClasshasMajorCreateModel createModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createModel);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5287/api/MajorhasClasses/MajorhasClasses/create", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5287/api/MajorhasClasses/{id}/delete");
            if (responseMessage.IsSuccessStatusCode)
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
            var responseMessage = await client.GetAsync($"http://localhost:5287/api/MajorhasClasses/{id}");
            if (responseMessage.IsSuccessStatusCode)
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
        public async Task<IActionResult> Update(ApiClasshasMajorUpdateModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model.Data);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5287/api/MajorhasClasses/MajorhasClasses/update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }




    }
}
