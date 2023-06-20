using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class OrderDao : BaseDao
    {
        public int PlaceOrder(Order order)
        {
            string insertOrderQuery = "INSERT INTO Orders (Employee_Id, Table_Id, Status, Placed_Time) VALUES (@EmployeeId, @TableId, @Status, @PlacedTime); SELECT SCOPE_IDENTITY();";

            decimal insertedOrderIdDecimal = ExecuteScalar<decimal>(insertOrderQuery, command =>
            {
                command.Parameters.AddWithValue("@EmployeeId", order.Employee.EmployeeId);
                command.Parameters.AddWithValue("@TableId", order.Table.TableId);
                command.Parameters.AddWithValue("@Status", order.Status.ToString());
                command.Parameters.AddWithValue("@PlacedTime", order.PlacedTime);
            });

            int insertedOrderId = Convert.ToInt32(insertedOrderIdDecimal);

            return insertedOrderId;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            string sqlQuery = "INSERT INTO Order_Item (Order_Id, Menu_Id, Quantity, Note, Unit_Price) VALUES (@OrderId, @MenuItem, @Quantity, @Note, @UnitPrice)";
            ExecuteNonQuery(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@OrderId", orderItem.Order.OrderId);
                command.Parameters.AddWithValue("@MenuItem", orderItem.MenuItem.MenuId);
                command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                command.Parameters.AddWithValue("@Note", orderItem.Note);
                command.Parameters.AddWithValue("@UnitPrice", orderItem.UnitPrice);
            });
        }

        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            string sqlQuery = "SELECT * FROM Order_Item WHERE Order_Id = @OrderId";
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
                    Price = Convert.ToDecimal(reader["Price"]),
                    IsAlcoholic = Convert.ToBoolean(reader["IsAlcoholic"]),
                    Category = new MenuCategory()
                    {
                        CategoryId = Convert.ToInt32(reader["Category_Id"]),
                        CategoryName = reader["CategoryName"].ToString()
                    },
                    MenuType = reader["MenuType"].ToString(),
                    Stock = Convert.ToInt32(reader["Stock"])
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

        public void UpdateOrderItem(OrderItem orderItem)
        {
            string sqlQuery = "UPDATE Order_Item SET Quantity = @Quantity, Note = @Note, Unit_Price = @UnitPrice WHERE Order_Item_Id = @OrderItemId";
            ExecuteNonQuery(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@OrderItemId", orderItem.OrderItemId);
                command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                command.Parameters.AddWithValue("@Note", orderItem.Note);
                command.Parameters.AddWithValue("@UnitPrice", orderItem.UnitPrice);
            });
        }

        public void DeleteOrderItem(int orderItemId)
        {
            string sqlQuery = "DELETE FROM Order_Item WHERE Order_Item_Id = @OrderItemId";
            ExecuteNonQuery(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@OrderItemId", orderItemId);
            });
        }
        public List<Order> GetORderByStatus(int TableID)
        {
            List<Order> orders = new List<Order>();
            string query = "SELECT Order_Id, Status, Placed_Time FROM Orders WHERE Status != @Status AND Table_Id = @TableID";
            try
            {

                SqlDataReader reader = ExecuteReader(query, command =>
                {
                    command.Parameters.AddWithValue("@Status", OrderStatus.OrderCompleted.ToString());
                    command.Parameters.AddWithValue("@TableID", TableID);
                });
                while (reader.Read())
                {
                    Order order = new Order
                    {
                        OrderId = Convert.ToInt32(reader["Order_Id"]),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), reader["Status"].ToString()),
                        PlacedTime = Convert.ToDateTime(reader["Placed_Time"]),
                        Employee = Employee.GetInstance(),
                        Table = new Table(),
                        OrderItems = new List<OrderItem>(),
                    };

                    orders.Add(order);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving orders by status: {ex.Message}");
            }
            return orders;
        }
    }
}
