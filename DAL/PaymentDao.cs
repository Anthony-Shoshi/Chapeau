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
        public int AddPayment(Payment payment)
        {
            string insertOrderQuery = "INSERT INTO Payment (Payment_Date, Tip, Comment, Order_Id, Amount, Cash_Amount, Payment_Method) " +
                                 "VALUES (@PaymentDate, @Tip, @Comment, @OrderId, @Amount, @CashAmount, @PaymentMethod);" +
                                 "SELECT SCOPE_IDENTITY();";

            int generatedPaymentId = 0;

            decimal insertedPaymentIdDecimal = ExecuteScalar<decimal>(insertOrderQuery, command =>
            {
                command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                command.Parameters.AddWithValue("@Tip", payment.Tip);
                command.Parameters.AddWithValue("@Comment", payment.Comment);
                command.Parameters.AddWithValue("@OrderId", payment.OrderId);
                command.Parameters.AddWithValue("@Amount", payment.Amount);
                command.Parameters.AddWithValue("@CashAmount", payment.CashAmount);
                command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod.ToString());
            });

            int insertedPaymentId = Convert.ToInt32(insertedPaymentIdDecimal);

            return insertedPaymentId;
        }


        public void AddBillSplit(BillSplit billSplit)
        {
            const string query = "INSERT INTO Bill_Split (Payment_Id, Number_Of_People, Amount_Per_Person) " +
                            "VALUES (@PaymentId, @NumberOfPeople, @AmountPerPerson)";

            Action<SqlCommand> parameterSetter = (command) =>
            {
                command.Parameters.AddWithValue("@PaymentId", billSplit.Payment.PaymentId);
                command.Parameters.AddWithValue("@NumberOfPeople", billSplit.NumberOfPeople);
                command.Parameters.AddWithValue("@AmountPerPerson", billSplit.AmountPerPerson);
            };

            ExecuteNonQuery(query, parameterSetter);
        }

    }

}

