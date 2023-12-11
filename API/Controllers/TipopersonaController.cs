using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipopersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public TipopersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipopersonaDto>>> Get()
        {
            var tipoPersona = await _unitOfWork.Tipopersonas.GetAllAsync();
            return _mapper.Map<List<TipopersonaDto>>(tipoPersona);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipopersonaDto>> Get(int id)
        {
            var tipoPersona = await _unitOfWork.Tipopersonas.GetByIdAsync(id);
            if (tipoPersona == null) return NotFound();
            return _mapper.Map<TipopersonaDto>(tipoPersona);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tipopersona>> Post(TipopersonaDto tipopersonaDto)
        {
            var tipoPersona = _mapper.Map<Tipopersona>(tipopersonaDto);
            _unitOfWork.Tipopersonas.Add(tipoPersona);
            await _unitOfWork.SaveAsync();
            if (tipoPersona == null) return BadRequest();
            tipopersonaDto.Id = tipoPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = tipopersonaDto.Id }, tipopersonaDto);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipopersonaDto>> Put(int id, [FromBody] TipopersonaDto tipopersonaDto)
        {
            if (tipopersonaDto == null) return NotFound();
            if (tipopersonaDto.Id == 0) tipopersonaDto.Id = id;
            if (tipopersonaDto.Id != id) return BadRequest();
            var tipoPersona = await _unitOfWork.Tipopersonas.GetByIdAsync(id);
            _mapper.Map(tipopersonaDto, tipoPersona);
            //tipoPersona.FechaModificacion = DateTime.Now;
            _unitOfWork.Tipopersonas.Update(tipoPersona);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TipopersonaDto>(tipoPersona);
        
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoPersona = await _unitOfWork.Tipopersonas.GetByIdAsync(id);
            if (tipoPersona == null) return NotFound();
            _unitOfWork.Tipopersonas.Remove(tipoPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}