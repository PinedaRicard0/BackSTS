﻿using sts_models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sts_i_daos
{
    public interface ID_Pool
    {
        Task<List<Pool>> GetPoolsByCategory(int categoryId);
    }
}
