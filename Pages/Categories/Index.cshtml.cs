using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSample.Models;

namespace RazorPagesSample.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public IHttpClientFactory _clientFactory;

        public IList<Category> Categories { get; set; }

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://et.saswafer.com/api/bazaar/getCategories/S");
            var responseStream = await response.Content.ReadAsStreamAsync();
            Categories = await JsonSerializer.DeserializeAsync<IList<Category>>(responseStream);
        }
    }
}