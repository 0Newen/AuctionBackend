using Aplication.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class VehicleRepo : IVehicleRepo
    {
        private readonly DataContext _dataBase;

        public VehicleRepo(DataContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<Vehicle> Create(Vehicle entity)
        {
            _dataBase.Vehicle.Add(entity);
            await _dataBase.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteById(int id)
        {
            await _dataBase.Vehicle.Where(x=> x.Id == id).ExecuteDeleteAsync();

            return true;
        }

        public Task<List<Vehicle>> GetAll()
        {
            return _dataBase.Vehicle.ToListAsync();
        }

        public Task<Vehicle> GetById(int id)
        {
           return _dataBase.Vehicle.FirstAsync(x => x.Id == id);
        }

        public async Task<Vehicle> Update(Vehicle entity)
        {
            _dataBase.Update(entity);
            await _dataBase.SaveChangesAsync();
            return entity;
        }
    }
}
