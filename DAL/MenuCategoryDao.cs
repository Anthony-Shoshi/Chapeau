using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class MenuCategoryDao : BaseDao
    {
        public List<MenuCategory> GetAllMenuCategories()
        {
            string query = "SELECT * FROM Menu_Category";
            List<MenuCategory> categories = new List<MenuCategory>();

            SqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                MenuCategory category = new MenuCategory();
                category.CategoryId = (int)reader["Category_Id"];
                category.CategoryName = (string)reader["Category_Name"];

                categories.Add(category);
            }
            reader.Close();

            return categories;
        }

        public MenuCategory GetMenuCategoryById(int categoryId)
        {
            string query = "SELECT * FROM Menu_Category WHERE Category_Id = @CategoryId";
            MenuCategory category = null;

            SqlDataReader reader = ExecuteReader(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            });

            if (reader.Read())
            {
                category = new MenuCategory();
                category.CategoryId = (int)reader["Category_Id"];
                category.CategoryName = (string)reader["Category_Name"];
            }

            reader.Close();

            return category;
        }

    }
}
