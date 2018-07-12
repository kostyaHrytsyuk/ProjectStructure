using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Common.DTO;

namespace BusinessLogic.Services
{
    interface IService<T> where T : BaseDto
    {
        List<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
