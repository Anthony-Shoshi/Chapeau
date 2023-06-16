﻿using System;
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

        public void PlaceOrder(Order order)
        {
            orderDao.PlaceOrder(order);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            orderDao.AddOrderItem(orderItem);
        }

        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            return orderDao.GetOrderItemsByOrderId(orderId);
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            orderDao.UpdateOrderStatus(orderId, status);
        }
    }
}