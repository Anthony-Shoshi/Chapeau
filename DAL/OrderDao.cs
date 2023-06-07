using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDao : BaseDao
    {
        public List<Order> GetAllOrders()
        {
            string query = "SELECT Order_Id, Employee_Id, Table_Id, Status, Placed_Time [dbo].[Order];";
            List<Order> orders = new List<Order>();
            SqlDataReader sqlDataReader = null;
            SqlDataReader reader = ExecuteReader(query, ((SqlCommand cmd) =>
            {
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Order order = new Order()
                    {
                        Id = (int)sqlDataReader["Menu_Id"],
                        EmployeeId = (int)sqlDataReader["Employee_Id"],
                        TableId = (int)sqlDataReader["Table_Id"],
                        Status = sqlDataReader["Status"].ToString(),
                        PlacedTime = TimeSpan.Parse(sqlDataReader["Placed_Time"].ToString()),
                    };
                    orders.Add(order);
                }
                sqlDataReader.Close();
            }));
            return orders;
        }

        public List<OrderRestaurantView> GetAllOrdersForRestaurantView()
        {
            string query = @"SELECT 
	                            [Order].Order_Id, 
	                            [Order].Employee_Id, 
	                            [Order].Table_Id, 
	                            [Order].Status AS ""Order_Status"", 
	                            [Order].Placed_Time AS ""Order_Place_Time"",
	                            [Order_Item].Quantity AS ""Item_Quantity"",
	                            [Order_Item].Note,
	                            [Order_Item].Unit_Price,
	                            [Menu_Item].Name AS ""Menu_Item_Name"",
	                            [Menu_Item].price,
	                            [Menu_Item].is_Alcoholic,
	                            [Menu_Item].Menu_Type,
	                            [Menu_Category].Category_Name,
	                            [Employee].Employee_Name,
	                            [Restaurant_Table].Number AS ""Table_Number"",
	                            [Restaurant_Table].Status AS ""Table_Status""
	                            FROM [Order]
	                            LEFT JOIN Order_Item ON [Order].Order_Id = Order_Item.Order_Id
	                            LEFT JOIN Employee ON [Order].Employee_Id = Employee.Employee_Id
	                            LEFT JOIN Restaurant_Table ON [Order].Table_Id = Restaurant_Table.Table_Id
	                            LEFT JOIN Menu_Item ON Order_Item.Menu_Id = Menu_Item.Menu_Id
	                            LEFT JOIN Menu_Category ON Menu_Category.Category_Id = Menu_Item.Category_Id
                                WHERE [Order].Status = 'Preparing'
                                ;";
            List<OrderRestaurantView> orders = new List<OrderRestaurantView>();
            SqlDataReader sqlDataReader = null;
            SqlDataReader reader = ExecuteReader(query, ((SqlCommand cmd) =>
            {
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    OrderRestaurantView order = new OrderRestaurantView()
                    {
                        Id = sqlDataReader["Order_Id"] is DBNull ? -1 : (int)sqlDataReader["Order_Id"],
                        EmployeeId = sqlDataReader["Employee_Id"] is DBNull ? -1 : (int)sqlDataReader["Employee_Id"],
                        TableId = sqlDataReader["Table_Id"] is DBNull ? -1 : (int)sqlDataReader["Table_Id"],
                        Status = sqlDataReader["Order_Status"] is DBNull ? "" : sqlDataReader["Order_Status"].ToString(),
                        PlacedTime = sqlDataReader["Order_Place_Time"] is DBNull ? new TimeSpan() : TimeSpan.Parse(sqlDataReader["Order_Place_Time"].ToString()),
                        Quantity = sqlDataReader["Item_Quantity"] is DBNull ? null : (int)sqlDataReader["Item_Quantity"],
                        Note = sqlDataReader["Note"] is DBNull ? null : sqlDataReader["Note"].ToString(),
                        UnitPrice = sqlDataReader["Unit_Price"] is DBNull ? null : Convert.ToDecimal(sqlDataReader["Unit_Price"]),
                        MenuItemName = sqlDataReader["Menu_Item_Name"] is DBNull ? null : sqlDataReader["Menu_Item_Name"].ToString(),
                        Price = sqlDataReader["price"] is DBNull ? null : Convert.ToDecimal(sqlDataReader["price"]),
                        IsAlcholic = sqlDataReader["is_Alcoholic"] is DBNull ? null : (bool)sqlDataReader["is_Alcoholic"],
                        MenuType = sqlDataReader["Menu_Type"] is DBNull ? null : sqlDataReader["Menu_Type"].ToString(),
                        CategoryName = sqlDataReader["Category_Name"] is DBNull ? null : sqlDataReader["Category_Name"].ToString(),
                        EmployeeName = sqlDataReader["Employee_Name"] is DBNull ? null : sqlDataReader["Employee_Name"].ToString(),
                        TableNumber = sqlDataReader["Table_Number"] is DBNull ? null : (int)sqlDataReader["Table_Number"],
                        TableStatus = sqlDataReader["Table_Status"] is DBNull ? null : sqlDataReader["Table_Status"].ToString(),
                    };
                    orders.Add(order);
                }
                sqlDataReader.Close();
            }));
            return orders;
        }
    }
}
