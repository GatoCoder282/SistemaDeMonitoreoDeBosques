using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaDeMonitoreoDeBosques.Api.Responses;
using SistemaDeMonitoreoDeBosques.Core.CustomEntities;
using SistemaDeMonitoreoDeBosques.Core.Entities;
using SistemaDeMonitoreoDeBosques.Core.Interfaces;
using SistemaDeMonitoreoDeBosques.Infraestructure.DTOs;

namespace SistemaDeMonitoreoDeBosques.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService _visitorService;
        private readonly IMapper _mapper;

        public VisitorController(IVisitorService visitorService, IMapper mapper)
        {
            _visitorService = visitorService;
            _mapper = mapper;
        }

        [HttpGet("dto/mapper")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _visitorService.GetAllVisitorAsync();
            var dtos = _mapper.Map<IEnumerable<VisitorDto>>(entities);
            return Ok(new ApiResponse<IEnumerable<VisitorDto>>(dtos));
        }

        [HttpGet("dto/mapper/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdRequest request)
        {
            var entity = await _visitorService.GetVisitorAsync(request.Id);
            if (entity == null) return NotFound("Visitante no encontrado");
            var dto = _mapper.Map<VisitorDto>(entity);
            return Ok(new ApiResponse<VisitorDto>(dto));
        }

        [HttpPost("dto/mapper")]
        public async Task<IActionResult> Create([FromBody] VisitorDto dto)
        {
            var entity = _mapper.Map<Visitor>(dto);

            await _visitorService.InsertVisitorAsync(entity);

            var resultDto = _mapper.Map<VisitorDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.id }, new ApiResponse<VisitorDto>(resultDto));
        }
        
        [HttpPut("dto/mapper/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] GetByIdRequest request, [FromBody] VehicleDto dto)
        {
            var entity = await _visitorService.GetVisitorAsync(request.Id);
            if (entity == null) return NotFound("Visitante no encontrado");

            _mapper.Map(dto, entity);
            await _visitorService.UpdateVisitorAsync(entity);

            var resultDto = _mapper.Map<VisitorDto>(entity);
            return Ok(new ApiResponse<VisitorDto>(resultDto));
        }

        [HttpDelete("dto/mapper/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] GetByIdRequest request)
        {
            var entity = await _visitorService.GetVisitorAsync(request.Id);
            if (entity == null) return NotFound("Visitante no encontrado");

            await _visitorService.DeleteVisitorAsync(entity);
            return NoContent();
        }
    }
}
