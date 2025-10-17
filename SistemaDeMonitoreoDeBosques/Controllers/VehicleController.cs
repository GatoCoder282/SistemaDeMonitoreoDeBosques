using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaDeMonitoreoDeBosques.Api.Responses;
using SistemaDeMonitoreoDeBosques.Core.Entities;
using SistemaDeMonitoreoDeBosques.Core.Interfaces;
using SistemaDeMonitoreoDeBosques.Infraestructure.DTOs;
using SistemaDeMonitoreoDeBosques.Core.CustomEntities;


namespace SistemaDeMonitoreoDeBosques.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        [HttpGet("dto/mapper")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _vehicleService.GetAllVehicleAsync();
            var dtos = _mapper.Map<IEnumerable<VehicleDto>>(entities);
            return Ok(new ApiResponse<IEnumerable<VehicleDto>>(dtos));
        }

        [HttpGet("dto/mapper/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdRequest request)
        {
            var entity = await _vehicleService.GetVehicleAsync(request.Id);
            if (entity == null) return NotFound("Vehículo no encontrado");
            var dto = _mapper.Map<VehicleDto>(entity);
            return Ok(new ApiResponse<VehicleDto>(dto));
        }

        [HttpPost("dto/mapper")]
        public async Task<IActionResult> Create([FromBody] VehicleDto dto)
        {
            var entity = _mapper.Map<Vehicle>(dto);
            await _vehicleService.InsertVehicleAsync(entity);
            var resultDto = _mapper.Map<VehicleDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.id }, new ApiResponse<VehicleDto>(resultDto));
        }

        [HttpPut("dto/mapper/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] GetByIdRequest request, [FromBody] VehicleDto dto)
        {
            var entity = await _vehicleService.GetVehicleAsync(request.Id);
            if (entity == null) return NotFound("Vehículo no encontrado");

            _mapper.Map(dto, entity);
            await _vehicleService.UpdateVehicleAsync(entity);
            var resultDto = _mapper.Map<VehicleDto>(entity);
            return Ok(new ApiResponse<VehicleDto>(resultDto));
        }

        [HttpDelete("dto/mapper/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] GetByIdRequest request)
        {
            var entity = await _vehicleService.GetVehicleAsync(request.Id);
            if (entity == null) return NotFound("Vehículo no encontrado");

            await _vehicleService.DeleteVehicleAsync(entity);
            return NoContent();
        }
    }
}
