using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContactoperController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public ContactoperController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactoperDto>>> Get()
        {
            var contactoPer = await _unitOfWork.Contactopers.GetAllAsync();
            return _mapper.Map<List<ContactoperDto>>(contactoPer);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoperDto>> Get(int id)
        {
            var contactoPer = await _unitOfWork.Contactopers.GetByIdAsync(id);
            if (contactoPer == null) return NotFound();
            return _mapper.Map<ContactoperDto>(contactoPer);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contactoper>> Post(ContactoperDto contactoperDto)
        {
            var contactoPer = _mapper.Map<Contactoper>(contactoperDto);
            _unitOfWork.Contactopers.Add(contactoPer);
            await _unitOfWork.SaveAsync();
            if (contactoPer == null) return BadRequest();
            contactoperDto.Id = contactoPer.Id;
            return CreatedAtAction(nameof(Post), new { id = contactoperDto.Id }, contactoperDto);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoperDto>> Put(int id, [FromBody] ContactoperDto contactoperDto)
        {
            if (contactoperDto == null) return NotFound();
            if (contactoperDto.Id == 0) contactoperDto.Id = id;
            if (contactoperDto.Id != id) return BadRequest();
            var contactoPer = await _unitOfWork.Contactopers.GetByIdAsync(id);
            _mapper.Map(contactoperDto, contactoPer);
            //contactoPer.FechaModificacion = DateTime.Now;
            _unitOfWork.Contactopers.Update(contactoPer);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ContactoperDto>(contactoPer);
        
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var contactoPer = await _unitOfWork.Contactopers.GetByIdAsync(id);
            if (contactoPer == null) return NotFound();
            _unitOfWork.Contactopers.Remove(contactoPer);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}