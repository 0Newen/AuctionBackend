using Aplication.Interfaces;
using Domain.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class FeeTypeRepo : IFeeTypeRepo
    {
        private readonly DataContext _dataBase;

        public FeeTypeRepo(DataContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<FeeType> Create(FeeType entity)
        {
           _dataBase.FeeType.Add(entity);
            await _dataBase.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteById(int id)
        {
            await _dataBase.FeeType.Where(x => x.Id == id).ExecuteDeleteAsync();

            return true;
        }

        public Task<List<FeeType>> GetAll()
        {
            return _dataBase.FeeType.ToListAsync();
        }

        public Task<FeeType> GetById(int id)
        {
            return _dataBase.FeeType.FirstAsync(x=> x.Id == id);
        }

        public async Task<FeeType> Update(FeeType entity)
        {
            _dataBase.Update(entity);
            await _dataBase.SaveChangesAsync();
            return entity;
        }
    }
}
