using System;
using System.Collections.Generic;
using EncompassRest.Loans.Enums;
using EncompassRest.Schema;

namespace EncompassRest.Loans
{
    /// <summary>
    /// RegulationZPayment
    /// </summary>
    public sealed partial class RegulationZPayment : ExtensibleObject, IIdentifiable
    {
        private DirtyValue<decimal?> _balance;
        /// <summary>
        /// RegulationZPayment Balance
        /// </summary>
        [LoanFieldProperty(Format = LoanFieldFormat.DECIMAL_2, ReadOnly = true)]
        public decimal? Balance { get => _balance; set => _balance = value; }
        private DirtyValue<string> _id;
        /// <summary>
        /// RegulationZPayment Id
        /// </summary>
        public string Id { get => _id; set => _id = value; }
        private DirtyValue<decimal?> _interestRatePercent;
        /// <summary>
        /// RegulationZPayment InterestRatePercent
        /// </summary>
        [LoanFieldProperty(Format = LoanFieldFormat.DECIMAL_3)]
        public decimal? InterestRatePercent { get => _interestRatePercent; set => _interestRatePercent = value; }
        private DirtyValue<decimal?> _monthlyPayment;
        /// <summary>
        /// RegulationZPayment MonthlyPayment
        /// </summary>
        [LoanFieldProperty(Format = LoanFieldFormat.DECIMAL_2)]
        public decimal? MonthlyPayment { get => _monthlyPayment; set => _monthlyPayment = value; }
        private DirtyValue<int?> _numberOfPayments;
        /// <summary>
        /// RegulationZPayment NumberOfPayments
        /// </summary>
        public int? NumberOfPayments { get => _numberOfPayments; set => _numberOfPayments = value; }
        private DirtyValue<DateTime?> _paymentDate;
        /// <summary>
        /// RegulationZPayment PaymentDate
        /// </summary>
        [LoanFieldProperty(ReadOnly = true)]
        public DateTime? PaymentDate { get => _paymentDate; set => _paymentDate = value; }
        private DirtyValue<int?> _regulationZPaymentIndex;
        /// <summary>
        /// RegulationZPayment RegulationZPaymentIndex
        /// </summary>
        public int? RegulationZPaymentIndex { get => _regulationZPaymentIndex; set => _regulationZPaymentIndex = value; }
        internal override bool DirtyInternal
        {
            get => _balance.Dirty
                || _id.Dirty
                || _interestRatePercent.Dirty
                || _monthlyPayment.Dirty
                || _numberOfPayments.Dirty
                || _paymentDate.Dirty
                || _regulationZPaymentIndex.Dirty;
            set
            {
                _balance.Dirty = value;
                _id.Dirty = value;
                _interestRatePercent.Dirty = value;
                _monthlyPayment.Dirty = value;
                _numberOfPayments.Dirty = value;
                _paymentDate.Dirty = value;
                _regulationZPaymentIndex.Dirty = value;
            }
        }
    }
}