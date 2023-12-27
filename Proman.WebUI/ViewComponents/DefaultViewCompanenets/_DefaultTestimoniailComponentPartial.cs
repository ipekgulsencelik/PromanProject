using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proman.WebUI.DTOs.TestimonialDTOs;

namespace Proman.WebUI.ViewComponents.DefaultViewCompanenets
{
    public class _DefaultTestimoniailComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTestimoniailComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7081/api/Testimonials/GetLast3ActiveTestimonials");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var testimonials = JsonConvert.DeserializeObject<List<ResultTestimonialDTO>>(jsonData);
                return View(testimonials);
            }
            return View();
        }
    }
}