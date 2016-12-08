using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.Accomendation")]
    public partial class Accomendation : IEntity<Guid>
    {
        #region Constructors

        public Accomendation()
        {
            ItemValues = new HashSet<ItemValue>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid ServiceTypeId { get; set; }
        public Guid ServiceRateId { get; set; }
        public Guid ServiceClassId { get; set; }

        #endregion

        #region Navigations

        [ForeignKey("ServiceClassId")]
        public virtual ServiceClass ServiceClass { get; set; }
        [ForeignKey("ServiceRateId")]
        public virtual ServiceRate ServiceRate { get; set; }
        [ForeignKey("ServiceTypeId")]
        public virtual ServiceType ServiceType { get; set; }
        public virtual ICollection<ItemValue> ItemValues { get; set; }

        #endregion
    }
}
