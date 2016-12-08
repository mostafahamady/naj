using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.ActivityType")]
    public partial class ActivityType : IEntity<Guid>
    {
        #region Constructors

        public ActivityType()
        {
            Activities = new HashSet<Activity>();
            ItemValues = new HashSet<ItemValue>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public bool IsAccomendation { get; set; }

        #endregion

        #region Navigations

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<ItemValue> ItemValues { get; set; }

        #endregion
    }
}
