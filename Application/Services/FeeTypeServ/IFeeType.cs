﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.FeeTypeServ
{
    public interface IFeeType
    {
        public Task<List<FeeType>> GetAll();
    }
}
