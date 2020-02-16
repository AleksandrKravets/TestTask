using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TestTask.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<string[]> GetFruits()
        {
            await Task.Delay(5000);

            string[] fruits = { "apple", "orange", "banana" };

            return fruits;
        }

        [HttpGet]
        public int[] GetNumbers()
        {
            int[] numbers = { 1, 2, 3 };

            return numbers;
        }
    }
}
