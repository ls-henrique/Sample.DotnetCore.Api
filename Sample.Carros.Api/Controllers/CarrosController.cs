using Microsoft.AspNetCore.Mvc;
using Sample.Carros.Dominio.Commands;
using Sample.Carros.Dominio.Handlers;
using Sample.Carros.Dominio.Repositorios;
using System.Threading.Tasks;

namespace Sample.Carros.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrosController : ControllerBase
    {
        private readonly ICarrosRepositorio carrosRepositorio;

        private readonly CarrosHandler carrosHandler;

        public CarrosController(ICarrosRepositorio carrosRepositorio, CarrosHandler carrosHandler)
        {
            this.carrosRepositorio = carrosRepositorio;
            this.carrosHandler = carrosHandler;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = this.carrosRepositorio.GetAll();
            return Ok(response);
        }

        //[Route("{nome}")]
        //[HttpGet]
        //public IActionResult Get(string nome)
        //{
        //    var response = this.carrosRepositorio.GetById(id);
        //    return Ok(response);
        //}

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var response = this.carrosRepositorio.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarCarroCommand command)
        {
            var response = await this.carrosHandler.Handle(command);
            if (response.Success)
                return Ok(response);

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AtualizarCarroCommand command)
        {
            var response = await this.carrosHandler.Handle(command);
            return Ok(response);
        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var command = new ExcluirCarroCommand(id);

        //    var response = await this.carrosHandler.Handle(command);
        //    return Ok(response);
        //}
    }
}
