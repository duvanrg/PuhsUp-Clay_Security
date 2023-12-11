using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DirpersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public DirpersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DirpersonaDto>>> Get()
        {
            var dirPersona = await _unitOfWork.Dirpersonas.GetAllAsync();
            return _mapper.Map<List<DirpersonaDto>>(dirPersona);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DirpersonaDto>> Get(int id)
        {
            var dirPersona = await _unitOfWork.Dirpersonas.GetByIdAsync(id);
            if (dirPersona == null) return NotFound();
            return _mapper.Map<DirpersonaDto>(dirPersona);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Dirpersona>> Post(DirpersonaDto dirpersonaDto)
        {
            var dirPersona = _mapper.Map<Dirpersona>(dirpersonaDto);
            _unitOfWork.Dirpersonas.Add(dirPersona);
            await _unitOfWork.SaveAsync();
            if (dirPersona == null) return BadRequest();
            dirpersonaDto.Id = dirPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = dirpersonaDto.Id }, dirpersonaDto);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DirpersonaDto>> Put(int id, [FromBody] DirpersonaDto dirpersonaDto)
        {
            if (dirpersonaDto == null) return NotFound();
            if (dirpersonaDto.Id == 0) dirpersonaDto.Id = id;
            if (dirpersonaDto.Id != id) return BadRequest();
            var dirPersona = await _unitOfWork.Dirpersonas.GetByIdAsync(id);
            _mapper.Map(dirpersonaDto, dirPersona);
            //dirPersona.FechaModificacion = DateTime.Now;
            _unitOfWork.Dirpersonas.Update(dirPersona);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DirpersonaDto>(dirPersona);
        
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var dirPersona = await _unitOfWork.Dirpersonas.GetByIdAsync(id);
            if (dirPersona == null) return NotFound();
            _unitOfWork.Dirpersonas.Remove(dirPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}