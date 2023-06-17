using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PaymentDao : BaseDao
    {
        public List<Payment> GetAllPayments()
        {
            List<Payment> payments = new();

            const string query = "SELECT * FROM Payment";

            Action<SqlCommand> parameterSetter = null;

            using (SqlDataReader reader = ExecuteReader(query, parameterSetter))
            {
                while (reader.Read())
                {
                    Payment payment = new Payment()
                    {
                        PaymentId = (int)reader["Payment_Id"],
                        PaymentDate = (DateTime)reader["Payment_Date"],
                        Tip = (decimal)reader["Tip"],
                        Comment = (string)reader["Comment"],
                        OrderId = (int)reader["Order_Id"],
                        Amount = (decimal)reader["Amount"]
                    };

                    payments.Add(payment);
                }
            }

            return payments;
        }


        public void AddPayment(Payment payment)
        {
            const string query = "INSERT INTO Payment (Payment_Date, Tip, Comment, Order_Id, Amount) " +
                            "VALUES (@PaymentDate, @Tip, @Comment, @OrderId, @Amount)";

            Action<SqlCommand> parameterSetter = (command) =>
            {
                command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                command.Parameters.AddWithValue("@Tip", payment.Tip);
                command.Parameters.AddWithValue("@Comment", payment.Comment);
                command.Parameters.AddWithValue("@OrderId", payment.Order.OrderId);
                command.Parameters.AddWithValue("@Amount", payment.Amount);
            };

            ExecuteNonQuery(query, parameterSetter);
        }

        public void UpdatePayment(Payment payment)
        {
            const string query = "UPDATE Payment SET Payment_Date = @PaymentDate, Tip = @Tip, Comment = @Comment, Order_Id = @OrderId, Amount = @Amount " +
                            "WHERE Payment_Id = @PaymentId";

            Action<SqlCommand> parameterSetter = (command) =>
            {
                command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                command.Parameters.AddWithValue("@Tip", payment.Tip);
                command.Parameters.AddWithValue("@Comment", payment.Comment);
                command.Parameters.AddWithValue("@OrderId", payment.Order.OrderId);
                command.Parameters.AddWithValue("@Amount", payment.Amount);
                command.Parameters.AddWithValue("@PaymentId", payment.PaymentId);
            };

            ExecuteNonQuery(query, parameterSetter);
        }

        public void DeletePayment(int paymentId)
        {
            const string query = "DELETE FROM Payment WHERE Payment_Id = @PaymentId";

            Action<SqlCommand> parameterSetter = (command) =>
            {
                command.Parameters.AddWithValue("@PaymentId", paymentId);
            };

            ExecuteNonQuery(query, parameterSetter);
        }

        public Payment GetPaymentById(int paymentId)
        {
            Payment payment = null;

            const string query = "SELECT * FROM Payment WHERE Payment_Id = @PaymentId";

            Action<SqlCommand> parameterSetter = (command) =>
            {
                command.Parameters.AddWithValue("@PaymentId", paymentId);
            };

            using (SqlDataReader reader = ExecuteReader(query, parameterSetter))
            {
                if (reader.Read())
                {
                    payment = new Payment()
                    {
                        PaymentId = (int)reader["Payment_Id"],
                        PaymentDate = (DateTime)reader["Payment_Date"],
                        Tip = (decimal)reader["Tip"],
                        Comment = (string)reader["Comment"],
                        OrderId = (int)reader["Order_Id"],
                        Amount = (decimal)reader["Amount"]
                    };
                }
            }

            return payment;
        }

        public List<Payment> GetPaymentsByOrderId(int orderId)
        {
            List<Payment> payments = new();

            const string query = "SELECT * FROM Payment WHERE Order_Id = @OrderId";

            Action<SqlCommand> parameterSetter = (command) =>
            {
                command.Parameters.AddWithValue("@OrderId", orderId);
            };

            using (SqlDataReader reader = ExecuteReader(query, parameterSetter))
            {
                while (reader.Read())
                {
                    Payment payment = new Payment()
                    {
                        PaymentId = (int)reader["Payment_Id"],
                        PaymentDate = (DateTime)reader["Payment_Date"],
                        Tip = (decimal)reader["Tip"],
                        Comment = (string)reader["Comment"],
                        OrderId = (int)reader["Order_Id"],
                        Amount = (decimal)reader["Amount"]
                    };

                    payments.Add(payment);
                }
            }

            return payments;
        }


        public List<Payment> GetPaymentsByEmployeeId(int employeeId)
        {
            List<Payment> payments = new();

            const string query = "SELECT * FROM Payment WHERE Employee_Id = @EmployeeId";

            Action<SqlCommand> parameterSetter = (command) =>
            {
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
            };

            using (SqlDataReader reader = ExecuteReader(query, parameterSetter))
            {
                while (reader.Read())
                {
                    Payment payment = new Payment()
                    {
                        PaymentId = (int)reader["Payment_Id"],
                        PaymentDate = (DateTime)reader["Payment_Date"],
                        Tip = (decimal)reader["Tip"],
                        Comment = (string)reader["Comment"],
                        OrderId = (int)reader["Order_Id"],
                        Amount = (decimal)reader["Amount"]
                    };

                    payments.Add(payment);
                }
            }

            return payments;
        }

        public List<string> GetTheNameOfOrderItems(int orderId)
        {
            List<string> itemNames = new List<string>();

            const string query = "SELECT name FROM Order_Item " +
                           "LEFT JOIN Menu_Item ON Order_Item.Menu_Id = Menu_Item.Menu_Id " +
                           "WHERE Order_Id = @OrderId";

            Action<SqlCommand> parameterSetter = (command) =>
            {
                command.Parameters.AddWithValue("@OrderId", orderId);
            };

            using (SqlDataReader reader = ExecuteReader(query, parameterSetter))
            {
                while (reader.Read())
                {
                    string itemName = (string)reader["name"];
                    itemNames.Add(itemName);
                }
            }

            return itemNames;
        }

    }

}

