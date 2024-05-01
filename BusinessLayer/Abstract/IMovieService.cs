﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMovieService:IGenericService<Movie>
    {
        List<Movie> TMovieWithCategoryAndDirector();
		List<Movie> TGetMoviesAdvices();
		List<Movie> TGetMoviesPrizes();
		List<Movie> TGetMoviesLikes();
		List<Movie> TGetMoviesRandom();
	}
}
