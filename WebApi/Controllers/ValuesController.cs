using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //[Route("api/[controller]")] // [controller] - w to miejsce zostanie wpisana nazwa kontrolera
    //[ApiController]
    public class ValuesController : ApiController //ControllerBase
    {
        //https://localhost:7027/api/v2/values //v2 dziedziczone z ApiController
        [HttpGet] //adnotacja określająca typ/czasownik zapytania
        public string GetValues()
        {
            return "1, 2, 3, 4, 5";
        }

        //https://localhost:7027/api/another/values
        [HttpGet("/api/another/[controller]")] // routing od roota - zaczyna się od "/"
        //https://localhost:7027/api/v2/values/another
        [HttpGet("another")] //routing - metoda dostępna pod adresem api/[controller]/another
        public string GetAnotherValues()
        {
            return "6, 7, 8, 9, 0";
        }

        //https://localhost:7027/api/v2/values/50?text1=hello&text2=hello
        [HttpGet("{param}")] //przekazanie parametru w adresie
        public string GetValues(int param, string text1, string? text2) //opcjonlanie można dodać parametry na zasadzie klucz wartrość (?text1=hello&text2=bye)
        {
            return text1 +  string.Join(",", Enumerable.Range(0, param).Select(x => x.ToString())) + text2;
        }
    }
}
