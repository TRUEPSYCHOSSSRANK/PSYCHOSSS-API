using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new List<string>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IActionResult GetAll([FromQuery] int? sortStrategy = null)
        {
            var result = Summaries.ToList();

            if (sortStrategy == 1)
            {
                result.Sort();
                return Ok(result);
            }

            if (sortStrategy == -1)
            {
                result.Sort();
                result.Reverse();
                return Ok(result);
            }

            if (sortStrategy != null)
            {
                return BadRequest("Некорректное значение параметра sortStrategy");
            }

            return Ok(result);
        }

        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Неверный индекс");

            return Ok(Summaries[index]);
        }

        [HttpGet("count/{name}")]
        public IActionResult GetCount(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Имя не может быть пустым");

            var count = Summaries.Count(n => n == name);
            return Ok(count);
        }

        [HttpPost]
        public IActionResult Add([FromBody] string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Имя не может быть пустым");

            Summaries.Add(name);
            return Ok($"Имя '{name}' успешно добавлено");
        }

        [HttpPut("{index}")]
        public IActionResult Update(int index, [FromBody] string name)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Неверный индекс");

            if (string.IsNullOrEmpty(name))
                return BadRequest("Имя не может быть пустым");

            var oldName = Summaries[index];
            Summaries[index] = name;
            return Ok($"Имя '{oldName}' изменено на '{name}'");
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Неверный индекс");

            var name = Summaries[index];
            Summaries.RemoveAt(index);
            return Ok($"Имя '{name}' успешно удалено");
        }
    }
}
