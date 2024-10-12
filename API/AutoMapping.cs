using API.Request;
using AutoMapper;
using Domain.Models;

namespace API
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateVehicleRequest, Vehicle>();
        }
    }
}
