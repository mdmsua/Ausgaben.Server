namespace Ausgaben.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        [ForeignKey("Parent")]
        public virtual List<Category> Categories { get; set; }

        public short Id { get; set; }

        public string Name { get; set; }

        [Column("ParentId")]
        public short? Parent { get; set; }

        public bool? Type { get; set; }
    }
}