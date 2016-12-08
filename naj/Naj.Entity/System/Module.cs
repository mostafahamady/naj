using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("System.Module")]
    public class Module : IEntity<Guid>
    {
        #region Constructors

        public Module()
        {
            Menus = new HashSet<Menu>();
        }

        #endregion

        #region Properties

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        #endregion

        #region Navigations

        public virtual ICollection<Menu> Menus { get; set; }

        #endregion
    }
}
