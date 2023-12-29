using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proman.WebUI.DTOs.ExperienceDTOs;

namespace Proman.WebUI.ViewComponents.DefaultViewCompanenets
{
    public class _DefaultExperienceListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultExperienceListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7081/api/Experiences/GetLast4ActiveExperiences");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var experiences = JsonConvert.DeserializeObject<List<ResultExperienceDTO>>(jsonData);
                return View(experiences);
            }
            return View();
        }
    }
}