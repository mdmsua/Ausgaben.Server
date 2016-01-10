namespace Ausgaben.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class TableEntity : ITableEntity
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public bool Deleted { get; set; }

        [Key]
        public Guid Id { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}