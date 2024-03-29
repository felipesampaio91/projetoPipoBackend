﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IBaseDomainService<T>
        where T : class
    {
        T Insert(T obj);
        T Update(T obj);
        void Delete(T obj);

        List<T> GetAll();
        T GetById(int id);
    }
}
