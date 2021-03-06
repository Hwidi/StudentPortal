﻿using System;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        T Get(Func<T, bool> predicate);
        void Add(T entity);
        void Edit(T entity);
    }
}
