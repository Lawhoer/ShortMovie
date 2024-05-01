﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMovieDal:IGenericDal<Movie>
    {
        List<Movie> GetMoviesWithCategoryandDirector();
        List<Movie> GetMoviesAdvices();
        List<Movie> GetMoviesPrizes();
        List<Movie> GetMoviesLikes();
        List<Movie> GetMoviesRandom();
    }
}
