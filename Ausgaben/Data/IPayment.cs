namespace Ausgaben.Data
{
    using System;

    public interface IPayment
    {
        Guid AccountId { get; set; }

        decimal Amount { get; set; }

        short CategoryId { get; set; }

        string Description { get; set; }

        DateTimeOffset? Timestamp { get; set; }
    }
}