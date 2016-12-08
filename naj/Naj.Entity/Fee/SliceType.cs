using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.SliceType")]
    public partial class SliceType : IEntity<Guid>
    {
        #region Constructors

        public SliceType()
        {
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

        public virtual ICollection<Slice> Slices { get; set; }

        #endregion
    }
}
