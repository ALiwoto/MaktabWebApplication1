using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaktabWebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string MyName { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        static HttpClient myAppHTTPClient = new HttpClient();

        public async void OnPostProcessRequestAsync()
        {
            string firstName, lastName, email;
            string host = "https://thirdparty.app.com:443/";
            string pathname = "path/to/api/endpoint/?operation=create";

            firstName = "Test";
            lastName = "User";
            email = "TestUser@email.com";

            string path = pathname + "&first_name=" + firstName + "&last_name=" + lastName + "&email=" + email;
            string requestUrl = host + path;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();

            try
            {
                HttpResponseMessage responseMessage = await myAppHTTPClient.PostAsync(requestUrl, httpRequestMessage.Content);
                HttpContent content = responseMessage.Content;
                string message = await content.ReadAsStringAsync();
                Console.WriteLine("The output from thirdparty is: {0}", message);
                RedirectToPage();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine("An HTTP request exception occurred. {0}", exception.Message);
            }
        }

        public string GetName()
        {
            return "Ali Abedini";
        }
    }
}