using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.Item")]
    public partial class Item : IEntity<Guid>
    {
        #region Constructors

        public Item()
        {
            ItemValues = new HashSet<ItemValue>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public Guid? ItemTypeId { get; set; }

        #endregion

        #region Navigations

        [ForeignKey("ItemTypeId")]
        public virtual ItemType ItemType { get; set; }
        public virtual ICollection<ItemValue> ItemValues { get; set; }

        #endregion
    }
}
