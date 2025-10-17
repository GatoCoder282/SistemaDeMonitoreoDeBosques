using AutoMapper;
using SistemaDeMonitoreoDeBosques.Core.Entities;
using SistemaDeMonitoreoDeBosques.Infraestructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaDeMonitoreoDeBosques.Infraestructure.Mappings
{
    public class MappingForest : Profile
    {
        public MappingForest()
        {
            CreateMap<Visitor, VisitorDto>();
            CreateMap<VisitorDto, Visitor>();


            CreateMap<Sensor, SensorDto>();
            CreateMap<SensorDto, Sensor>();


            CreateMap<Forest, ForestDto>();
            CreateMap<ForestDto, Forest>();


            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Vehicle>();
        }
    }
}
