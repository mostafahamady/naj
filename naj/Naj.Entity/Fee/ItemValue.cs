using Naj.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Fee.ItemValue")]
    public partial class ItemValue : IEntity<Guid>
    {
        #region Constructors

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public decimal? Value { get; set; }
        public Guid ItemId { get; set; }
        public Guid? ItemOperationId { get; set; }
        public Guid? SliceId { get; set; }
        public Guid? BuildingUsageId { get; set; }
        public Guid? ActivityTypeId { get; set; }
        public Guid? AccomendationId { get; set; }
        public Guid? UnitId { get; set; }
        public Guid? SegementId { get; set; }
        public int? Duration { get; set; }
        public Guid? DurationId { get; set; }

        #endregion

        #region Navigations

        [ForeignKey("AccomendationId")]
        public virtual Accomendation Accomendation { get; set; }
        [ForeignKey("ActivityTypeId")]
        public virtual ActivityType ActivityType { get; set; }
        [ForeignKey("BuildingUsageId")]
        public virtual BuildingUsage BuildingUsage { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
        [ForeignKey("ItemOperationId")]
        public virtual ItemOperation ItemOperation { get; set; }
        [ForeignKey("SegementId")]
        public virtual Segement Segement { get; set; }
        [ForeignKey("SliceId")]
        public virtual Slice Slice { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
        [ForeignKey("DurationId")]
        public virtual Duration Duration_ { get; set; }

        #endregion
    }
}
