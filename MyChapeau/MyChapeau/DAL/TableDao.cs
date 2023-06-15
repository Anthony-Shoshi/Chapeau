﻿using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class TableDao : BaseDao
    {
        public List<Table> GetAllTables()
        {
            string query = "SELECT * FROM Restaurant_Table";
            List<Table> tables = new List<Table>();

            SqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                Table table = new Table();
                table.TableId = (int)(reader["Table_Id"]);
                table.Number = (int)(reader["Number"]);
                
                if (Enum.TryParse(reader["Status"].ToString(), out TableStatus status))
                {
                    table.Status = status;
                }
                else
                {
                    table.Status = TableStatus.Occupied;
                }

                tables.Add(table);
            }
            reader.Close();

            return tables;
        }
    }
}