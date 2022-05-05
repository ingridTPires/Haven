using Haven.Enums;
using Haven.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Haven.Controllers
{
    [ApiController]
    [Route("api/enderecos")]
    public class EnderecoController : Controller
    {
        private readonly ApiContext _context;

        public EnderecoController(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Recuperar todos os endereços
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Endereco.ToListAsync());

        /// <summary>
        /// Recuperar nivel de criminalidade por cep: baixo/medio/alto
        /// </summary>
        [HttpGet]
        [Route("{cep}/nivel-criminalidade")]
        public async Task<IActionResult> GetNivelCriminalidade([FromRoute]string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return BadRequest();

            var endereco = await _context.Endereco.Include(x => x.Ocorrencias).FirstOrDefaultAsync(x => x.Cep == cep);

            if (endereco == null)
                return NotFound("Endereço não encontrado");

            var qtdOcorrencia = endereco.Ocorrencias.Count();

            if (qtdOcorrencia > 40)
                return Ok(NivelCriminalidade.Alto.ToString());
            else if (qtdOcorrencia > 10)
                return Ok(NivelCriminalidade.Medio.ToString());

            return Ok(NivelCriminalidade.Baixo.ToString());
        }


        /// <summary>
        /// Recupera os depoimentos por cep
        /// </summary>
        [HttpGet]
        [Route("{cep}/depoimentos")]
        public async Task<IActionResult> GetDepoimentos([FromRoute] string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return BadRequest();

            var endereco = await _context.Endereco.Include(x => x.Depoimentos).FirstOrDefaultAsync(x => x.Cep == cep);

            if (endereco == null)
                return NotFound("Endereço não encontrado");

            return Ok(endereco.Depoimentos);
        }
    }
}