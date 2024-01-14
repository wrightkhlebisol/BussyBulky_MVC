using BussyBulky.DataAccess.Data;
using BussyBulky.DataAccess.Repository.IRepository;
using BussyBulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussyBulky.DataAccess.Repository
{
	public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
		private ApplicationDbContext _db;
		public OrderDetailRepository(ApplicationDbContext db) : base(db) 
		{ 
			_db = db;
		}
		public void Update(OrderDetail obj)
		{
			_db.OrderDetails.Update(obj);
		}
	}
}
