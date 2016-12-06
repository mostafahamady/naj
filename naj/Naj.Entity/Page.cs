using Naj.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("System.Page")]
    public class Page : IEntity<Guid>
    {
        #region Constructors

        #endregion

        #region Properties

        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Brief { get; set; }
        [Required]
        [StringLength(200)]
        public string URL { get; set; }
        public Guid MenuID { get; set; }

        #endregion

        #region Navigations

        [ForeignKey("MenuID")]
        public virtual Menu Menu { get; set; }

        #endregion
    }
}
