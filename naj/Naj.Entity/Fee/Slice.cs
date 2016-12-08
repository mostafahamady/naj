using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.Slice")]
    public partial class Slice : IEntity<Guid>
    {
        #region Constructors

        public Slice()
        {
            ItemValues = new HashSet<ItemValue>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public Guid UnitId { get; set; }
        public Guid? SliceTypeId { get; set; }

        #endregion

        #region Navigations

        public virtual ICollection<ItemValue> ItemValues { get; set; }
        [ForeignKey("SliceTypeId")]
        public virtual SliceType SliceType { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }

        #endregion
    }
}
