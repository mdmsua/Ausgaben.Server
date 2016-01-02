namespace Ausgaben.Data
{
    using System;

    using Microsoft.Azure.Mobile.Server.Tables;

    public interface ITableEntity
    {
        [TableColumn(TableColumnType.CreatedAt)]
        DateTimeOffset? CreatedAt { get; set; }

        [TableColumn(TableColumnType.Deleted)]
        bool Deleted { get; set; }

        [TableColumn(TableColumnType.Id)]
        Guid Id { get; set; }

        [TableColumn(TableColumnType.UpdatedAt)]
        DateTimeOffset? UpdatedAt { get; set; }

        [TableColumn(TableColumnType.Version)]
        byte[] Version { get; set; }
    }
}