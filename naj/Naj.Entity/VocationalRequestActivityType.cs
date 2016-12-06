using Naj.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Momra.Data.Entities
{
    [Table("Baladi.VocationalRequestActivityType")]
    public class VocationalRequestActivityType : IEntity<Guid>
    {
        #region Constructors

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public Guid VocationalRequestId { get; set; }
        public Guid RequestActivityTypeId { get; set; }

        #endregion

        #region Navigations

        [ForeignKey("VocationRequestId")]
        public virtual VocationalRequest VocationalRequest { get; set; }

        [ForeignKey("RequestActivityTypeId")]
        public virtual RequestActivityType RequestActivityType { get; set; }

        #endregion
    }
}
