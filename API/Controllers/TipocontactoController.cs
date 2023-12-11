using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipocontactoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public TipocontactoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipocontactoDto>>> Get()
        {
            var tipoContacto = await _unitOfWork.Tipocontactos.GetAllAsync();
            return _mapper.Map<List<TipocontactoDto>>(tipoContacto);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipocontactoDto>> Get(int id)
        {
            var tipoContacto = await _unitOfWork.Tipocontactos.GetByIdAsync(id);
            if (tipoContacto == null) return NotFound();
            return _mapper.Map<TipocontactoDto>(tipoContacto);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tipocontacto>> Post(TipocontactoDto tipocontactoDto)
        {
            var tipoContacto = _mapper.Map<Tipocontacto>(tipocontactoDto);
            _unitOfWork.Tipocontactos.Add(tipoContacto);
            await _unitOfWork.SaveAsync();
            if (tipoContacto == null) return BadRequest();
            tipocontactoDto.Id = tipoContacto.Id;
            return CreatedAtAction(nameof(Post), new { id = tipocontactoDto.Id }, tipocontactoDto);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipocontactoDto>> Put(int id, [FromBody] TipocontactoDto tipocontactoDto)
        {
            if (tipocontactoDto == null) return NotFound();
            if (tipocontactoDto.Id == 0) tipocontactoDto.Id = id;
            if (tipocontactoDto.Id != id) return BadRequest();
            var tipoContacto = await _unitOfWork.Tipocontactos.GetByIdAsync(id);
            _mapper.Map(tipocontactoDto, tipoContacto);
            //tipoContacto.FechaModificacion = DateTime.Now;
            _unitOfWork.Tipocontactos.Update(tipoContacto);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TipocontactoDto>(tipoContacto);
        
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoContacto = await _unitOfWork.Tipocontactos.GetByIdAsync(id);
            if (tipoContacto == null) return NotFound();
            _unitOfWork.Tipocontactos.Remove(tipoContacto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}