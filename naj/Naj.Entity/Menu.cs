using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("System.Menu")]
    public class Menu : IEntity<Guid>
    {
        #region Constructors

        public Menu()
        {
            Pages = new List<Page>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        public int Sort { get; set; }
        public string Icon { get; set; }
        public Guid ModuleID { get; set; }

        #endregion

        #region Navigations

        [ForeignKey("ModuleID")]
        public virtual Module Module { get; set; }
        public virtual ICollection<Page> Pages { get; set; }

        #endregion
    }
}
