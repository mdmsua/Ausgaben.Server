namespace Ausgaben.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class TableEntity : ITableEntity
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public bool Deleted { get; set; }

        [Key]
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}