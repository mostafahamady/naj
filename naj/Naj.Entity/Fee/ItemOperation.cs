using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.ItemOperation")]
    public partial class ItemOperation : IEntity<Guid>
    {
        #region Constructors

        public ItemOperation()
        {
            ItemValues = new HashSet<ItemValue>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        #endregion

        #region Navigations

        public virtual ICollection<ItemValue> ItemValues { get; set; }

        #endregion
    }
}
