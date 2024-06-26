﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class PersonalManager : IPersonalService
	{
		IPersonalDal _personalDal;

		public PersonalManager(IPersonalDal personalDal)
		{
			_personalDal = personalDal;
		}

		public void TAdd(Personal t)
		{
			_personalDal.Insert(t);
		}

		public void TDelete(Personal t)
		{
			_personalDal.Delete(t);
		}

		public Personal TGetByID(int id)
		{
			return _personalDal.GetByID(id);
		}

		public List<Personal> TGetList()
		{
			return _personalDal.GetList();
		}

        public List<Personal> TPersonalMessage(string s)
        {
			return _personalDal.PersonalMessage(s);
        }

        public void TUpdate(Personal t)
		{
			_personalDal.Update(t);
		}
	}
}
