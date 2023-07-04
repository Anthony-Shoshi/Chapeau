using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace Service
{
    public class OrderService
    {
        private OrderDao orderDao;

        public OrderService()
        {
            orderDao = new OrderDao();
        }

        public int PlaceOrder(Order order)
        {
            return orderDao.PlaceOrder(order);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            orderDao.AddOrderItem(orderItem);
        }

        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            return orderDao.GetOrderItemsByOrderId(orderId);
        }
        public List<Order> GetOrders()
        {
            return orderDao.GetAllOrders();
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            orderDao.UpdateOrderStatus(orderId, status);
        }
        public void UpdateOrderItemStatus(int orderId, int menuId, OrderItemStatus status)
        {
            orderDao.UpdateOrderItemStatus(orderId, menuId, status);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            orderDao.UpdateOrderItem(orderItem);
        }

        public void DeleteOrderItem(int orderItemId)
        {
            orderDao.DeleteOrderItem(orderItemId);
        }
        public List<Order> GetOrderByStatus(int TableID)
        {
            return orderDao.GetORderByStatus(TableID);
        }
        
        public Order GetOrderWithItemsByTableId(int TableID)
        {
            return orderDao.GetOrderWithItemsByTableId(TableID);
        }
    }
}
