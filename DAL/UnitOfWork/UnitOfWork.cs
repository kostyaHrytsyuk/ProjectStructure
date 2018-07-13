﻿using System;
using System.Collections.Generic;
using DAL.Repositories;
using DAL.Models;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataSource _context;

        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        {
            if (repositories.ContainsKey(typeof(TEntity)))
            {
                return repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var newRepository = new Repository<TEntity>(_context);
            repositories.Add(typeof(TEntity), newRepository);
            return newRepository;
        }
        
        public UnitOfWork(DataSource context)
        {
            _context = context;
        }
    }
}
