using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proman.WebUI.DTOs.TeamDTOs;

namespace Proman.WebUI.ViewComponents.DefaultViewCompanenets
{
    public class _DefaultTeamComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTeamComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7081/api/Teams/GetLast3ActiveTeams");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var team = JsonConvert.DeserializeObject<List<ResultTeamDTO>>(jsonData);
                return View(team);
            }
            return View();
        }
    }
}