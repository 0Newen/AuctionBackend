using Aplication.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.FeeTypeServ
{
    public class FeeTypeService : IFeeType
    {
        private readonly IFeeTypeRepo _feeTypeRepo;

        public FeeTypeService(IFeeTypeRepo feeTypeRepo)
        {
            _feeTypeRepo = feeTypeRepo;
        }

        public Task<List<FeeType>> GetAll()
        {
            return _feeTypeRepo.GetAll();
        }
    }
}
