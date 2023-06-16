using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class OrderDao : BaseDao
    {
        public void PlaceOrder(Order order)
        {
            string sqlQuery = "INSERT INTO Orders (Employee_Id, Table_Id, Status, Placed_Time) VALUES (@EmployeeId, @TableId, @Status, @PlacedTime); SELECT SCOPE_IDENTITY();";
            ExecuteNonQuery(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@EmployeeId", order.Employee.EmployeeId);
                command.Parameters.AddWithValue("@TableId", order.Table.TableId);
                command.Parameters.AddWithValue("@Status", order.Status.ToString());
                command.Parameters.AddWithValue("@PlacedTime", order.PlacedTime);
            });
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            string sqlQuery = "INSERT INTO Order_Item (Order_Id, Menu_Id, Quantity, Note, Unit_Price) VALUES (@OrderId, @MenuId, @Quantity, @Note, @UnitPrice)";
            ExecuteNonQuery(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@OrderId", orderItem.Order.OrderId);
                command.Parameters.AddWithValue("@MenuId", orderItem.MenuItem.MenuId);
                command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                command.Parameters.AddWithValue("@Note", orderItem.Note);
                command.Parameters.AddWithValue("@UnitPrice", orderItem.UnitPrice);
            });
        }

        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            string sqlQuery = "SELECT oi.*, m.* FROM Order_Item oi INNER JOIN MenuItem m ON oi.Menu_Id = m.Menu_Id WHERE oi.Order_Id = @OrderId";
            List<OrderItem> orderItems = new List<OrderItem>();
            SqlDataReader reader = ExecuteReader(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@OrderId", orderId);
            });

            while (reader.Read())
            {
                MenuItem menuItem = new MenuItem()
                {
                    MenuId = Convert.ToInt32(reader["Menu_Id"]),
                    Name = reader["Name"].ToString(),
                    // Populate other properties of MenuItem as needed
                };

                OrderItem orderItem = new OrderItem()
                {
                    OrderItemId = Convert.ToInt32(reader["Order_Item_Id"]),
                    Order = null, // The Order object will be assigned later
                    MenuItem = menuItem,
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Note = reader["Note"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["Unit_Price"])
                };

                orderItems.Add(orderItem);
            }

            return orderItems;
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            string sqlQuery = "UPDATE Orders SET Status = @Status WHERE Order_Id = @OrderId";
            ExecuteNonQuery(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@Status", status.ToString());
            });
        }
    }
}
