﻿using BussyBulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BussyBulky.DataAccess.Repository.IRepository
{
	public interface IOrderDetailRepository : IRepository<OrderDetail

    {
		void Update(OrderDetail obj);
	}
}
