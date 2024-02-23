using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Mvc.Models.ClasshasMajorModel;
using School.Mvc.Models.ClassModel;
using School.Mvc.Models.StudentModel;
using System.Net.Http;
using System.Text;

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
                    
                    throw new Exception("JSON dönüşüm hatası", ex);
                }
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5287/api/Student/{id}/Students/GetbyId");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                try
                {
                    var values = JsonConvert.DeserializeObject<ApiStudentListModel>(jsonData);
                    return View(values);
                }
                catch (JsonSerializationException ex)
                {

                    throw new Exception("JSON dönüşüm hatası", ex);
                }
            }

            return View();

        }

        public async Task<IActionResult> Delete(int id)
        {
           
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5287/api/Student/{id}/delete");
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5287/api/Student/student/create", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CreateParent");
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateParent()
        { return View(); }

        [HttpPost]
        public async Task<IActionResult> CreateParent(ParentCreateModel model)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5287/api/Parent/Parent/create", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("CreateShasMC");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> CreateShasMC()
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5287/api/MajorhasClasses/MajorhasClasses/getall");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ClasshasMajorListModel>>(jsonData);

            ViewBag.MC = values;
            return View(); 
        }


		[HttpPost]
		public async Task<IActionResult> CreateShasMC(StudenthasMajorClassCreateModel model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5287/api/StudenthasMajorClasseshasMajorClasses/StudenthasMajorClasses/create", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("CreateShasMC");
			}

			return View();
		}
	}
}
