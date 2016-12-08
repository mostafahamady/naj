using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Baladi.RequestActivityType")]
    public class RequestActivityType : IEntity<Guid>
    {
        #region Constructors

        public RequestActivityType()
        {
            VocationalRequestActivityTypes = new HashSet<VocationalRequestActivityType>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int ActivityTypeId { get; set; }
        public int SubActivityTypeId { get; set; }
        public int? DetailedActivityTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ActivityTypeCode { get; set; }

        [Required]
        [StringLength(50)]
        public string SubActivityTypeCode { get; set; }

        [StringLength(50)]
        public string DetailedActivityTypeCode { get; set; }

        #endregion

        #region Navigations

        public virtual ICollection<VocationalRequestActivityType> VocationalRequestActivityTypes { get; set; }

        #endregion
    }
}
