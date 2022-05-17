using BilgeAdam.MVCRocks.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BilgeAdam.MVCRocks.Components
{
    public class DropDownViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string url, string property)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:9000");
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                var options = JsonSerializer.Deserialize<List<DropDownOptionViewModel.Option>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var result = new DropDownOptionViewModel(options)
                {
                    Property = property
                };
                return View(result);
            }
        }
    }
}
