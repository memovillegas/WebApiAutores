using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAutores.Entidades;

namespace WebAPIAutores.Controllers
{
    //Validaciones automaticas respecto a la data recibida en nuestro controlador
    [ApiController]
    [Route("api/Autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public AutoresController(ApplicationDBContext context)
        {
            this.context = context;
        }

        //funcion puntual que se va a ejecutar
        [HttpGet]
        public async Task<ActionResult<List<Autor>>>Get() 
        {
            return await context.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult>Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
