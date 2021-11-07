using System;
using System.Collections.Generic;
using System.Text;
using exFixInterface.Services;

namespace exFixInterface.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public int NumberOfInstallments { get; set; }

        private List<Installment> Installments = new List<Installment>();
        private IPaymentService _paymentService;

        public Contract()
        {}

        public Contract(int number, DateTime date, double totalValue, int numberOfInstallments, IPaymentService paymentService)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
            NumberOfInstallments = numberOfInstallments;
            _paymentService = paymentService;
            for(int i = 0; i < NumberOfInstallments; i++)
            {
                Installment installment = new Installment(date.AddMonths(i), totalValue / NumberOfInstallments);
                installment.Amount = CalcInvoice(_paymentService, i+1);
                Installments.Add(installment);
            }
            
        }

        public double CalcInvoice(IPaymentService paymentService, int installmenNumber)
        {
            return paymentService.Installment(TotalValue / NumberOfInstallments, installmenNumber);            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Number: ");
            sb.AppendLine(Number.ToString());            
            sb.Append("Date: ");
            sb.AppendLine(Date.ToString("dd/MM/yyyy"));
            sb.Append("Contract Value: ");
            sb.AppendLine(TotalValue.ToString());
            sb.Append("Number of Insatllments: ");
            sb.AppendLine(NumberOfInstallments.ToString());
            sb.AppendLine("Installments:");
            foreach(Installment item in Installments)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
