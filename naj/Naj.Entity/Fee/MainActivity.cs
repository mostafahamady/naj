using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.MainActivity")]
    public partial class MainActivity : IEntity<Guid>
    {
        #region Constructors

        public MainActivity()
        {
            Activities = new HashSet<Activity>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        #endregion

        #region Navigations

        public virtual ICollection<Activity> Activities { get; set; }

        #endregion
    }
}
