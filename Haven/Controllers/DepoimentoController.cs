using Haven.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Haven.Controllers
{
    [ApiController]
    [Route("api/depoimentos")]
    public class DepoimentoController : Controller
    {
        private readonly ApiContext _context;

        public DepoimentoController(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Recuperar todos os depoimentos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Depoimento.ToListAsync());

        /// <summary>
        /// Recuperar todos os depoimentos pelo cpf do usuário
        /// </summary>
        [Authorize]
        [HttpGet]
        [Route("usuario/{cpf}")]
        public async Task<IActionResult> Get([FromRoute] string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return BadRequest();

            var depoimentos = await _context.Depoimento.Include(x => x.Usuario).Where(x => x.Usuario.Cpf == cpf).ToListAsync();

            return Ok(depoimentos);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Depoimento depoimento)
        {
            _context.Add(depoimento);
            await _context.SaveChangesAsync();

            return Ok(depoimento);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Depoimento depoimento)
        {
            var depoimentoDb = await _context.Depoimento.FindAsync(id);

            if (depoimentoDb == null)
                return NotFound();

            depoimentoDb.Descricao = depoimento.Descricao;
            depoimentoDb.ModalidadeCrime = depoimento.ModalidadeCrime;

            _context.Depoimento.Attach(depoimentoDb);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var depoimento = await _context.Depoimento.FindAsync(id);

            if (depoimento == null)
                return NotFound();

            _context.Depoimento.Remove(depoimento);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}