﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Actions
{
    public interface IReadRepository<T,TKey> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(TKey id);
    }
}