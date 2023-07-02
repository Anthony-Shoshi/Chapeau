using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class KitchenService
    {
        private KitchenDao kitchenDao;

        public KitchenService()
        {
            this.kitchenDao = new KitchenDao();
        }

        public List<Order> GetOrders()
        {
            return kitchenDao.GetAllOrders();
        }

        public void UpdateOrderItemStatus(int orderId, int menuId, OrderItemStatus status)
        {
            kitchenDao.UpdateOrderItemStatus(orderId, menuId, status);
        }


    }


}
