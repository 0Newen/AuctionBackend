using Aplication.Services.FeeTypeServ;
using Aplication.Services.TypeVehicle;
using Aplication.Services.VehicleFee;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IVehicleFee, VehicleFeeService>();
            services.AddScoped<IVehicleType, VehicleTypeService>();
            services.AddScoped<IFeeType, FeeTypeService>();

            return services;
        }
    }
}
