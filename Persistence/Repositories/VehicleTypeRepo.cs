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
    public class VehicleTypeRepo : IVehicleTypeRepo
    {

        private readonly DataContext _dataBase;

        public VehicleTypeRepo(DataContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<VehicleType> Create(VehicleType entity)
        {
            _dataBase.VehicleType.Add(entity);
            await _dataBase.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int id)
        {
            await _dataBase.VehicleType.Where(X => X.Id == id).ExecuteDeleteAsync();
            return true;
        }

        public Task<List<VehicleType>> GetAll()
        {
           return _dataBase.VehicleType.ToListAsync();
        }

        public Task<VehicleType> GetById(int id)
        {
            return _dataBase.VehicleType.FirstAsync(x => x.Id == id);
        }

        public async Task<VehicleType> Update(VehicleType entity)
        {
            _dataBase.Update(entity);
            await _dataBase.SaveChangesAsync();
            return entity;
        }
    }
}
