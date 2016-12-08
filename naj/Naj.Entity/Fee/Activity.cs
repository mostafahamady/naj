using Naj.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.Activity")]
    public partial class Activity : IEntity<Guid>
    {
        #region Constructors

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        public Guid MainActivityId { get; set; }
        public Guid ActivityTypeId { get; set; }

        #endregion

        #region Navigations

        [ForeignKey("ActivityTypeId")]
        public virtual ActivityType ActivityType { get; set; }
        [ForeignKey("MainActivityId")]
        public virtual MainActivity MainActivity { get; set; }

        #endregion
    }
}
