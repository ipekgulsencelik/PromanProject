using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proman.WebUI.DTOs.EducationDTOs;

namespace Proman.WebUI.ViewComponents.DefaultViewCompanenets
{
    public class _DefaultEducationListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultEducationListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7081/api/Educations/GetLast4ActiveEducations");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var educations = JsonConvert.DeserializeObject<List<ResultEducationDTO>>(jsonData);
                return View(educations);
            }
            return View();
        }
    }
}