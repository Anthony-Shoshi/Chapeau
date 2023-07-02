using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KitchenDao : BaseDao
    {
        public List<Order> GetAllOrders()
        {
            string sqlQuery = @"SELECT [Orders].[Order_Id] 
               ,[Orders].[Employee_Id]
               ,[Orders].[Status]
               ,[Orders].[Placed_Time]
               ,[Restaurant_Table].[Table_Id]
               ,[Restaurant_Table].Number
               ,[Restaurant_Table].Status AS 'Table_Status'
               ,[Order_Item].Note
               ,[Order_Item].Quantity
               ,[Order_Item].Unit_Price
               ,[Order_Item].Status As 'Order_Item_Status'
			   ,[Menu_Item].Menu_Id
               ,[Menu_Item].Name
               ,[Menu_Item].Is_Alcoholic
			   ,[Menu_Item].Menu_Type
               ,[Employee].Employee_Id
			   ,[Employee].Employee_Name
			   ,[Employee].User_Type
			   ,[Menu_Category].Category_Id
               ,[Menu_Category].Category_Name FROM [dbo].[Orders]
               LEFT JOIN [Restaurant_Table] ON [Orders].Table_Id = [Restaurant_Table].Table_Id
               LEFT JOIN [Order_Item]  ON [Orders].Order_Id = [Order_Item].Order_Id
               LEFT JOIN [Menu_Item] ON [Menu_Item].Menu_id = [Order_Item].Menu_Id
               LEFT JOIN [Menu_Category] ON [Menu_Category].Category_Id = [Menu_Item].Category_Id
               LEFT JOIN [Employee] ON [Employee].Employee_Id = [Orders].Employee_Id";
            List<Order> orders = new List<Order>();
            List<OrderItem> orderItems = new List<OrderItem>();
            List<int> fetchedIds = new List<int>();
            SqlDataReader reader = ExecuteReader(sqlQuery, command =>
            {

            });

            while (reader.Read())
            {
                int orderId = Convert.ToInt32(reader["Order_Id"]);
                if (!fetchedIds.Contains(orderId))
                {
                    Table table = new Table()
                    {
                        Number = Convert.ToInt32(reader["Number"]),
                        Status = (TableStatus)Enum.Parse(typeof(TableStatus), reader["Table_Status"].ToString()),
                    };
                    Order order = new Order()
                    {
                        OrderId = orderId,
                        PlacedTime = Convert.ToDateTime(reader["Placed_Time"]),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), reader["Status"].ToString()),
                        Table = table,
                        OrderItems = new List<OrderItem>(),
                    };
                    orders.Add(order);
                    fetchedIds.Add(orderId);
                }
                MenuItem menuItem = new MenuItem()
                {
                    MenuId = Convert.ToInt32(reader["Menu_Id"]),
                    MenuType = reader["Menu_Type"].ToString(),
                    Name = reader["Name"].ToString(),
                    IsAlcoholic = Convert.ToBoolean(reader["Is_Alcoholic"]),
                    Category = new MenuCategory()
                    {
                        CategoryId = Convert.ToInt32(reader["Category_Id"]),
                        CategoryName = reader["Category_Name"].ToString()
                    },
                };
                OrderItemStatus orderItemStatus = reader["Order_Item_Status"] is DBNull ? OrderItemStatus.Ordered : (OrderItemStatus)Enum.Parse(typeof(OrderItemStatus), reader["Order_Item_Status"].ToString());
                OrderItem orderItem = new OrderItem()
                {
                    Order = new Order()
                    {
                        OrderId = Convert.ToInt32(reader["Order_Id"])
                    },
                    MenuItem = menuItem,
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Note = reader["Note"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["Unit_Price"]),
                    Status = orderItemStatus
                };

                orderItems.Add(orderItem);
            }

            foreach (Order order in orders)
            {
                order.OrderItems.AddRange(orderItems.Where(x => x.Order.OrderId.Equals(order.OrderId)));
            }

            return orders;
        }
        public void UpdateOrderItemStatus(int orderId, int menuId, OrderItemStatus status)
        {
            string sqlQuery = "UPDATE [Order_Item] SET Status = @Status WHERE Order_Id = @OrderId AND [Menu_Id] = @MenuId";
            ExecuteNonQuery(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@MenuId", menuId);
                command.Parameters.AddWithValue("@Status", status.ToString());
            });
        }
    }
}
