using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.ServiceClass")]
    public partial class ServiceClass : IEntity<Guid>
    {
        #region Constructors

        public ServiceClass()
        {
            Accomendations = new HashSet<Accomendation>();
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

        public virtual ICollection<Accomendation> Accomendations { get; set; }

        #endregion
    }
}
