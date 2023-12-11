using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriaperController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CategoriaperController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaperDto>>> Get()
        {
            var categoriaPer = await _unitOfWork.categoriapers.GetAllAsync();
            return _mapper.Map<List<CategoriaperDto>>(categoriaPer);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaperDto>> Get(int id)
        {
            var categoriaPer = await _unitOfWork.categoriapers.GetByIdAsync(id);
            if (categoriaPer == null) return NotFound();
            return _mapper.Map<CategoriaperDto>(categoriaPer);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Categoriaper>> Post(CategoriaperDto categoriaperDto)
        {
            var categoriaPer = _mapper.Map<Categoriaper>(categoriaperDto);
            _unitOfWork.categoriapers.Add(categoriaPer);
            await _unitOfWork.SaveAsync();
            if (categoriaPer == null) return BadRequest();
            categoriaperDto.Id = categoriaPer.Id;
            return CreatedAtAction(nameof(Post), new { id = categoriaperDto.Id }, categoriaperDto);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaperDto>> Put(int id, [FromBody] CategoriaperDto categoriaperDto)
        {
            if (categoriaperDto == null) return NotFound();
            if (categoriaperDto.Id == 0) categoriaperDto.Id = id;
            if (categoriaperDto.Id != id) return BadRequest();
            var categoriaPer = await _unitOfWork.categoriapers.GetByIdAsync(id);
            _mapper.Map(categoriaperDto, categoriaPer);
            //categoriaPer.FechaModificacion = DateTime.Now;
            _unitOfWork.categoriapers.Update(categoriaPer);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<CategoriaperDto>(categoriaPer);
        
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var categoriaPer = await _unitOfWork.categoriapers.GetByIdAsync(id);
            if (categoriaPer == null) return NotFound();
            _unitOfWork.categoriapers.Remove(categoriaPer);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}