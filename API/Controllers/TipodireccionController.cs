using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipodireccionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public TipodireccionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipodireccionDto>>> Get()
        {
            var tipoDireccion = await _unitOfWork.Tipodirecciones.GetAllAsync();
            return _mapper.Map<List<TipodireccionDto>>(tipoDireccion);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipodireccionDto>> Get(int id)
        {
            var tipoDireccion = await _unitOfWork.Tipodirecciones.GetByIdAsync(id);
            if (tipoDireccion == null) return NotFound();
            return _mapper.Map<TipodireccionDto>(tipoDireccion);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tipodireccion>> Post(TipodireccionDto tipodireccionDto)
        {
            var tipoDireccion = _mapper.Map<Tipodireccion>(tipodireccionDto);
            _unitOfWork.Tipodirecciones.Add(tipoDireccion);
            await _unitOfWork.SaveAsync();
            if (tipoDireccion == null) return BadRequest();
            tipodireccionDto.Id = tipoDireccion.Id;
            return CreatedAtAction(nameof(Post), new { id = tipodireccionDto.Id }, tipodireccionDto);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipodireccionDto>> Put(int id, [FromBody] TipodireccionDto tipodireccionDto)
        {
            if (tipodireccionDto == null) return NotFound();
            if (tipodireccionDto.Id == 0) tipodireccionDto.Id = id;
            if (tipodireccionDto.Id != id) return BadRequest();
            var tipoDireccion = await _unitOfWork.Tipodirecciones.GetByIdAsync(id);
            _mapper.Map(tipodireccionDto, tipoDireccion);
            //tipoDireccion.FechaModificacion = DateTime.Now;
            _unitOfWork.Tipodirecciones.Update(tipoDireccion);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TipodireccionDto>(tipoDireccion);
        
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoDireccion = await _unitOfWork.Tipodirecciones.GetByIdAsync(id);
            if (tipoDireccion == null) return NotFound();
            _unitOfWork.Tipodirecciones.Remove(tipoDireccion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}