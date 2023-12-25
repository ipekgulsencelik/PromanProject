using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proman.WebUI.DTOs.SocialMediaDTOs;

namespace Proman.WebUI.ViewComponents.DefaultViewCompanenets
{
    public class _DefaultSocialMediaComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7081/api/SocialMedias/GetLast4ActiveSocialMedias");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var accounts = JsonConvert.DeserializeObject<List<ResultSocialMediaDTO>>(jsonData);
                return View(accounts);
            }
            return View();
        }
    }
}