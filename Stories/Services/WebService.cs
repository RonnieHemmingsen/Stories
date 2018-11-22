using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Stories.Models;
using Stories.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebService))]
namespace Stories.Services
{
    public interface IWebService
    {
        Task<IEnumerable<Story>> GetStories();
    }


    public class WebService : IWebService
    {

        HttpClient _httpClient;
        HttpClient Client => _httpClient ?? (_httpClient = new HttpClient());
        readonly string _baseUrl = "https://storiesfuntions.azurewebsites.net/";

        public async Task<IEnumerable<Story>> GetStories()
        {
            var json = await Client.GetStringAsync(_baseUrl + "stories");
            var all = Story.FromJson(json);
            return all;
        }
    }
}
