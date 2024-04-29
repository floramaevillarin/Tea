﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Fiftea.DataAccess.Infrastructure
{
	public interface IRepository<T> where T : class
	{
		void Add(T entity);
		void Delete(Expression<Func<T, bool>> where);
		void Delete(T entity);
		T Get(Expression<Func<T, bool>> where);
		IEnumerable<T> GetAll();
		T GetById(int id);
		IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
		void Update(T entity);
		void Insert(T entity);
	}
}