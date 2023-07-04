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

        public int AddPayment(Payment payment)
        {
            return _paymentDao.AddPayment(payment);
        }

        public void AddBillSplit (BillSplit billSplit)
        {
            _paymentDao.AddBillSplit(billSplit);
        }
    }
}

