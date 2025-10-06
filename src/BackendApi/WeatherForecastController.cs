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
                return BadRequest("������������ �������� ��������� sortStrategy");
            }

            return Ok(result);
        }

        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("�������� ������");

            return Ok(Summaries[index]);
        }

        [HttpGet("count/{name}")]
        public IActionResult GetCount(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("��� �� ����� ���� ������");

            var count = Summaries.Count(n => n == name);
            return Ok(count);
        }

        [HttpPost]
        public IActionResult Add([FromBody] string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("��� �� ����� ���� ������");

            Summaries.Add(name);
            return Ok($"��� '{name}' ������� ���������");
        }

        [HttpPut("{index}")]
        public IActionResult Update(int index, [FromBody] string name)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("�������� ������");

            if (string.IsNullOrEmpty(name))
                return BadRequest("��� �� ����� ���� ������");

            var oldName = Summaries[index];
            Summaries[index] = name;
            return Ok($"��� '{oldName}' �������� �� '{name}'");
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("�������� ������");

            var name = Summaries[index];
            Summaries.RemoveAt(index);
            return Ok($"��� '{name}' ������� �������");
        }
    }
}
