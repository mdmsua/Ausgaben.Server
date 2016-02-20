namespace Ausgaben.Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.Azure.Mobile.Server;

    public class PaymentEntity : EntityData, IPayment
    {
        public Guid AccountId { get; set; }

        public decimal Amount { get; set; }

        public virtual Category Category { get; set; }

        public short CategoryId { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? Timestamp { get; set; }
    }
}