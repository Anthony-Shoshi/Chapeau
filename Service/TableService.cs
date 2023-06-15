using DAL;
using Model;

namespace Service
{
    public class TableService
    {
        private readonly TableDao tableDao;

        public TableService()
        {
            tableDao = new TableDao();
        }

        public List<Table> GetAllTables()
        {
            return tableDao.GetAllTables();
        }
    }
}
