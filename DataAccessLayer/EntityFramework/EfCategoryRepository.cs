﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
	{
		public List<Category> CategoriesWithMovies()
		{
			using (var c = new Context())
			{
				return c.Categories.Include(x => x.Movies).ToList();
			}
		}

		
	}
}
