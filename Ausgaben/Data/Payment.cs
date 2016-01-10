namespace Ausgaben.Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Payment : TableEntity, IPayment
    {
        public Guid AccountId { get; set; }

        public decimal Amount { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public short CategoryId { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? Timestamp { get; set; }
    }
}