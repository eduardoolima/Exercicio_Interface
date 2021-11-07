using System;
using exFixInterface.Entities;

namespace exFixInterface.Services
{
    class PaypalService : IPaymentService
    {
        public double Installment(double installment, int installmentNumber)
        {
            double installmentValue = installment + (installment * 0.01) * installmentNumber;
            return installmentValue + (installmentValue * 0.02);
        }
    }
}
