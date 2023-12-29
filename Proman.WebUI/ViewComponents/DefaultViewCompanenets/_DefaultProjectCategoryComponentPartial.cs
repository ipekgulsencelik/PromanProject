using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proman.WebUI.DTOs.ProjectTypeDTOs;

namespace Proman.WebUI.ViewComponents.DefaultViewCompanenets
{
	public class _DefaultProjectCategoryComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultProjectCategoryComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7081/api/ProjectTypes/GetLast2ActiveProjectTypes");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var categories = JsonConvert.DeserializeObject<List<ResultProjectTypeDTO>>(jsonData);
				return View(categories);
			}
			return View();
		}
	}
}