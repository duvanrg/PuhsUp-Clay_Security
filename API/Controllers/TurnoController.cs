using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TurnoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public TurnoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TurnoDto>>> Get()
        {
            var turno = await _unitOfWork.Turnos.GetAllAsync();
            return _mapper.Map<List<TurnoDto>>(turno);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TurnoDto>> Get(int id)
        {
            var turno = await _unitOfWork.Turnos.GetByIdAsync(id);
            if (turno == null) return NotFound();
            return _mapper.Map<TurnoDto>(turno);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Turno>> Post(TurnoDto turnoDto)
        {
            var turno = _mapper.Map<Turno>(turnoDto);
            _unitOfWork.Turnos.Add(turno);
            await _unitOfWork.SaveAsync();
            if (turno == null) return BadRequest();
            turnoDto.Id = turno.Id;
            return CreatedAtAction(nameof(Post), new { id = turnoDto.Id }, turnoDto);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TurnoDto>> Put(int id, [FromBody] TurnoDto turnoDto)
        {
            if (turnoDto == null) return NotFound();
            if (turnoDto.Id == 0) turnoDto.Id = id;
            if (turnoDto.Id != id) return BadRequest();
            var turno = await _unitOfWork.Turnos.GetByIdAsync(id);
            _mapper.Map(turnoDto, turno);
            //turno.FechaModificacion = DateTime.Now;
            _unitOfWork.Turnos.Update(turno);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TurnoDto>(turno);
        
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var turno = await _unitOfWork.Turnos.GetByIdAsync(id);
            if (turno == null) return NotFound();
            _unitOfWork.Turnos.Remove(turno);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}