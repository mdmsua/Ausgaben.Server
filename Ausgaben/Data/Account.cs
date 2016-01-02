namespace Ausgaben.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.Azure.Mobile.Server;
    public class Account : TableEntity, IAccount
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string User { get; set; }
        
    }
}