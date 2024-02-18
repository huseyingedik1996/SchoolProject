using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Mvc.Models.ClassModel;
using School.Mvc.Models.MajorModel;
using System.Text;

namespace School.Mvc.Controllers
{
	public class MajorController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public MajorController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5287/api/Majors/Major/getall");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ApiMajorListModel>(jsonData);
				return View(values);
			}
			return View();
		}


		[HttpGet]
		public IActionResult CreateMajor()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateMajor(MajorCreateModel createModel)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createModel);
			StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5287/api/Majors/Major/create", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}


		public async Task<IActionResult> Delete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5287/api/Majors/{id}/delete");
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
			var responseMessage = await client.GetAsync($"http://localhost:5287/api/Majors/1{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<ApiMajorUpdateModel>(jsonData);
				return View(value);
			}
			else
			{
				return View();
			}
		}


		[HttpPost]
		public async Task<IActionResult> Update(ApiMajorUpdateModel model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model.Data);
			StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:5287/api/Majors/Major/update/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}
			return View();
		}
	}
}
