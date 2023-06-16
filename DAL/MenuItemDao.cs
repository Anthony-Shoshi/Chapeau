using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class MenuItemDao : BaseDao
    {
        MenuCategoryDao menuCategoryDao;

        public MenuItemDao()
        {
            menuCategoryDao = new MenuCategoryDao();
        }

        public List<MenuItem> GetMenuItemsByCategoryId(int categoryId)
        {
            string query = "SELECT * FROM Menu_Item WHERE Category_Id = @CategoryId";
            List<MenuItem> items = new List<MenuItem>();

            SqlDataReader reader = ExecuteReader(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            });

            while (reader.Read())
            {
                MenuItem item = new MenuItem();
                item.MenuId = (int)reader["Menu_Id"];
                item.Name = (string)reader["Name"];
                item.Price = (decimal)reader["Price"];
                item.IsAlcoholic = (bool)reader["Is_Alcoholic"];
                item.Category = menuCategoryDao.GetMenuCategoryById((int)reader["Category_Id"]);
                item.MenuType = (string)reader["Menu_Type"];
                item.Stock = (int)reader["Stock"];

                items.Add(item);
            }
            reader.Close();

            return items;
        }

        public List<MenuItem> GetAllMenuItems()
        {
            string query = "SELECT * FROM Menu_Item";
            List<MenuItem> items = new List<MenuItem>();

            SqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                MenuItem item = new MenuItem();
                item.MenuId = (int)reader["Menu_Id"];
                item.Name = (string)reader["Name"];
                item.Price = (decimal)reader["Price"];
                item.IsAlcoholic = (bool)reader["Is_Alcoholic"];
                item.Category = menuCategoryDao.GetMenuCategoryById((int)reader["Category_Id"]);
                item.MenuType = (string)reader["Menu_Type"];
                item.Stock = (int)reader["Stock"];

                items.Add(item);
            }
            reader.Close();

            return items;
        }

        public bool AddMenuItem(MenuItem menuItem)
        {
            string query = "INSERT INTO Menu_Item (Name, Price, Is_Alcoholic, Category_Id, Menu_Type, Stock) " +
                           "VALUES (@Name, @Price, @IsAlcoholic, @CategoryId, @MenuType, @Stock)";
            try
            {
                ExecuteNonQuery(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@Name", menuItem.Name);
                    cmd.Parameters.AddWithValue("@Price", menuItem.Price);
                    cmd.Parameters.AddWithValue("@IsAlcoholic", menuItem.IsAlcoholic);
                    cmd.Parameters.AddWithValue("@CategoryId", menuItem.Category.CategoryId);
                    cmd.Parameters.AddWithValue("@MenuType", menuItem.MenuType);
                    cmd.Parameters.AddWithValue("@Stock", menuItem.Stock);
                });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DeleteMenuItem(int menuId)
        {
            string query = "DELETE FROM Menu_Item WHERE Menu_Id = @MenuId";

            ExecuteNonQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@MenuId", menuId);
            });
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            string query = "UPDATE Menu_Item SET Name = @Name, Price = @Price, Is_Alcoholic = @IsAlcoholic, " +
                           "Category_Id = @CategoryId, Menu_Type = @MenuType, Stock = @Stock " +
                           "WHERE Menu_Id = @MenuId";

            ExecuteNonQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Name", menuItem.Name);
                cmd.Parameters.AddWithValue("@Price", menuItem.Price);
                cmd.Parameters.AddWithValue("@IsAlcoholic", menuItem.IsAlcoholic);
                cmd.Parameters.AddWithValue("@CategoryId", menuItem.Category.CategoryId);
                cmd.Parameters.AddWithValue("@MenuType", menuItem.MenuType);
                cmd.Parameters.AddWithValue("@Stock", menuItem.Stock);
                cmd.Parameters.AddWithValue("@MenuId", menuItem.MenuId);
            });
        }

    }
}
