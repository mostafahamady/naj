using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.Segement")]
    public partial class Segement : IEntity<Guid>
    {
        #region Constructors

        public Segement()
        {
            ItemValues = new HashSet<ItemValue>();
            Municipalities = new HashSet<Municipality>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(1)]
        public string Name { get; set; }

        #endregion

        #region Navigations

        public virtual ICollection<ItemValue> ItemValues { get; set; }
        public virtual ICollection<Municipality> Municipalities { get; set; }

        #endregion
    }
}
