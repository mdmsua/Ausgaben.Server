namespace Ausgaben.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public short Id { get; set; }

        [Column("ParentId")]
        public short? Parent { get; set; }

        public string Name { get; set; }

        public bool? Type { get; set; }

        [ForeignKey("Parent")]
        public virtual List<Category> Categories { get; set; }
    }
}