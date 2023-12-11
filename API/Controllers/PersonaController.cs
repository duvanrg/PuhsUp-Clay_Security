using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var persona = await _unitOfWork.Personas.GetAllAsync();
            return _mapper.Map<List<PersonaDto>>(persona);
        }
        [HttpGet("ListEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> ListEmployees()
        {
            var persona = await _unitOfWork.Personas.ListEmployees();
            return _mapper.Map<List<PersonaDto>>(persona);

        }
        [HttpGet("SelectVigilante")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> SelectVigilante()
        {
            var persona = await _unitOfWork.Personas.SelectVigilante();
            return _mapper.Map<List<PersonaDto>>(persona);
        }
        [HttpGet("SelectPhoneOfVigilante")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> SelectPhoneOfVigilante()
        {
            var persona = await _unitOfWork.Personas.SelectPhoneOfVigilante();
            return Ok(persona);
        }
        [HttpGet("SelectClientsInBGA")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> SelectClientsInBGA()
        {
            var persona = await _unitOfWork.Personas.SelectClientsInBGA();
            return _mapper.Map<List<PersonaDto>>(persona);
        }

        [HttpGet("ListEmployeesInGrnAndPdc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> ListEmployeesInGrnAndPdc()
        {
            var persona = await _unitOfWork.Personas.ListEmployeesInGrnAndPdc();
            return _mapper.Map<List<PersonaDto>>(persona);
        }

        [HttpGet("SelectClients5Years")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> SelectClients5Years()
        {
            var persona = await _unitOfWork.Personas.SelectClients5Years();
            return _mapper.Map<List<PersonaDto>>(persona);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (persona == null) return NotFound();
            return _mapper.Map<PersonaDto>(persona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Persona>> Post(PersonaDto personaDto)
        {
            var persona = _mapper.Map<Persona>(personaDto);
            _unitOfWork.Personas.Add(persona);
            await _unitOfWork.SaveAsync();
            if (persona == null) return BadRequest();
            personaDto.Id = persona.Id;
            return CreatedAtAction(nameof(Post), new { id = personaDto.Id }, personaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto personaDto)
        {
            if (personaDto == null) return NotFound();
            if (personaDto.Id == 0) personaDto.Id = id;
            if (personaDto.Id != id) return BadRequest();
            var persona = await _unitOfWork.Personas.GetByIdAsync(id);
            _mapper.Map(personaDto, persona);
            //persona.FechaModificacion = DateTime.Now;
            _unitOfWork.Personas.Update(persona);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PersonaDto>(persona);

        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (persona == null) return NotFound();
            _unitOfWork.Personas.Remove(persona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}