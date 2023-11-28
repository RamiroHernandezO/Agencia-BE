using Application.Interface;
using Application.Main;
using Data.AgenciaDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AgenciaAutomoviles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefaccionController : ControllerBase
    {
        private readonly RefaccionApplication _agenciaContext;
        public RefaccionController(RefaccionApplication AgenciaContext)
        {
            _agenciaContext = AgenciaContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] RefaccionDTO RefaccionDTO)
        {
            if (RefaccionDTO == null)
            {
                return BadRequest();
            }
            var res = await _agenciaContext.Insert(RefaccionDTO);
            if (res.Success)
                return Ok(res.Data);

            return BadRequest(res.Message);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] RefaccionDTO RefaccionDTO)
        {
            if (RefaccionDTO == null)
            {
                return BadRequest();
            }
            var res = await _agenciaContext.Update(RefaccionDTO);
            if (res.Success)
                return Ok(res.Data);
            return BadRequest(res.Message);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            var res = _agenciaContext.GetAll().Result;
            return res.Success ? Ok(res.Data) : BadRequest(res.Message);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _agenciaContext.Get(id);
            return res.Success ? Ok(res.Data) : BadRequest(res.Message);

        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _agenciaContext.Delete(id);
            if (res.Success)
                return Ok(res.Data);

            return BadRequest(res.Message);
        }
    }
}