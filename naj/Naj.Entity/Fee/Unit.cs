using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.Unit")]
    public partial class Unit : IEntity<Guid>
    {
        #region Constructors

        public Unit()
        {
            ItemValues = new HashSet<ItemValue>();
            Slices = new HashSet<Slice>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        #endregion

        #region Navigations

        public virtual ICollection<ItemValue> ItemValues { get; set; }
        public virtual ICollection<Slice> Slices { get; set; }

        #endregion
    }
}
