using Naj.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.Municipality")]
    public partial class Municipality : IEntity<Guid>
    {
        #region Constructors

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public Guid SegementId { get; set; }

        #endregion

        #region Navigations

        [ForeignKey("SegementId")]
        public virtual Segement Segement { get; set; }

        #endregion
    }
}
