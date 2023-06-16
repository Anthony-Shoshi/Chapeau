using System.Data.SqlClient;
using DAL;
using Model;

namespace Service
{
    public class MenuService
    {
        private MenuCategoryDao categoryDao;
        private MenuItemDao itemDao;
        public MenuService()
        {
            categoryDao = new MenuCategoryDao();
            itemDao = new MenuItemDao();
        }

        public List<MenuCategory> GetAllMenuCategories()
        {
            return categoryDao.GetAllMenuCategories();
        }

        public List<MenuItem> GetMenuItemsByCategoryId(int categoryId)
        {
            return itemDao.GetMenuItemsByCategoryId(categoryId);
        }
        
        public List<MenuItem> GetMenuItems()
        {
            return itemDao.GetAllMenuItems();
        }

        public MenuCategory GetMenuCategoryById(int categoryId)
        {
            return categoryDao.GetMenuCategoryById(categoryId);
        }

        public bool AddMenuItem(MenuItem menuItem)
        {
            return itemDao.AddMenuItem(menuItem);
        }

        public void DeleteMenuItem(int menuId)
        {
            itemDao.DeleteMenuItem(menuId);
        }

        public bool UpdateMenuItem(MenuItem menuItem)
        {
            try
            {
                itemDao.UpdateMenuItem(menuItem);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
