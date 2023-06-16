using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PaymentService
    {
        private readonly PaymentDao _paymentDao;

        public PaymentService()
        {
            _paymentDao = new PaymentDao();
        }

        public List<Payment> GetAllPayments()
        {
            return _paymentDao.GetAllPayments();
        }

        public void AddPayment(Payment payment)
        {
            _paymentDao.AddPayment(payment);
        }

        public void UpdatePayment(Payment payment)
        {
            _paymentDao.UpdatePayment(payment);
        }

        public void DeletePayment(int paymentId)
        {
            _paymentDao.DeletePayment(paymentId);
        }

        public Payment GetPaymentById(int paymentId)
        {
            return _paymentDao.GetPaymentById(paymentId);
        }

        public List<Payment> GetPaymentsByOrderId(int orderId)
        {
            return _paymentDao.GetPaymentsByOrderId(orderId);
        }

        public List<Payment> GetPaymentsByEmployeeId(int employeeId)
        {
            return _paymentDao.GetPaymentsByEmployeeId(employeeId);
        }

        public List<string> GetTheNameOfOrderItems(int orderId)
        {
            return _paymentDao.GetTheNameOfOrderItems(orderId);
        }
    }
}

