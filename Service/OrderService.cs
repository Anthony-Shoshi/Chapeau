using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService
    {
        private OrderDao orderDao;

        public OrderService()
        {
            orderDao = new OrderDao();
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = orderDao.GetAllOrders();
            return orders;
        }

        public List<OrderRestaurantView> GetOrderRestaurantViews()
        {
            List<OrderRestaurantView> orders = orderDao.GetAllOrdersForRestaurantView();
            return orders;
        }
    }
}
