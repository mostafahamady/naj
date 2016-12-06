using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Momra.Data.Entities
{
    [Table("Baladi.VocationRequest")]
    public class VocationalRequest : IEntity<Guid>
    {
        #region Constructors

        public VocationalRequest()
        {
            VocationalRequestActivityTypes = new HashSet<VocationalRequestActivityType>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string RequestNumber { get; set; }

        public DateTime CreatedOn { get; set; }
        public int? EngineeringOfficeId { get; set; }

        [StringLength(50)]
        public string EngineeringOfficeCode { get; set; }

        public int StatusId { get; set; }
        public Guid MunicipalityId { get; set; }
        public Guid SubMunicipalityId { get; set; }

        [StringLength(50)]
        public string AuthorizationNumber { get; set; }

        public DateTime? AuthorizationDate { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string SecondName { get; set; }

        [StringLength(50)]
        public string ThirdName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public int? IdentityTypeId { get; set; }

        [StringLength(50)]
        public string IdentityNo { get; set; }

        [StringLength(50)]
        public string IdentitySource { get; set; }

        public DateTime? IdentityIssueDate { get; set; }
        public DateTime? IdentityEndDate { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string CommercialRecordNumber { get; set; }

        public DateTime? CRIssueDate { get; set; }
        public DateTime? CRExpirationDate { get; set; }

        [StringLength(50)]
        public string CRSource { get; set; }

        [StringLength(50)]
        public string ShopName { get; set; }

        public int? ActivityId { get; set; }
        public double ShopArea { get; set; }
        public int HolesCount { get; set; }

        [Required]
        [StringLength(50)]
        public string ShopAddress { get; set; }

        public double BoardArea { get; set; }
        public int BoardTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string BuildingLicensingNumber { get; set; }

        public DateTime BuildingLicensingDate { get; set; }

        [StringLength(50)]
        public string PlotNo { get; set; }

        [StringLength(50)]
        public string Latitude { get; set; }

        [StringLength(50)]
        public string Longitude { get; set; }

        [StringLength(50)]
        public string LocationDescription { get; set; }

        [StringLength(50)]
        public string LocationStreet { get; set; }

        [StringLength(50)]
        public string LocationDistrict { get; set; }

        [StringLength(50)]
        public string LocationSubDistrict { get; set; }

        [StringLength(50)]
        public string LocationMunicipal { get; set; }

        public Guid? LocationSubMunicipalityId { get; set; }
        public int? LocationMainDistrictId { get; set; }
        public int? LocationSubDistrictId { get; set; }
        public int? LocationStreetId { get; set; }

        [StringLength(50)]
        public string LocationMainDistrictCode { get; set; }

        [StringLength(50)]
        public string LocationSubDistrictCode { get; set; }

        [StringLength(50)]
        public string LocationStreetCode { get; set; }

        public int? RequestSubmitterTypeId { get; set; }
        public int? UserTypeId { get; set; }
        public byte[] Attachments { get; set; }
        public Guid RequestSubmitterInfoId { get; set; }

        #endregion

        #region Navigations

        [ForeignKey("RequestSubmitterInfoId")]
        public virtual RequestSubmitterInfo RequestSubmitterInfo { get; set; }

        public virtual ICollection<VocationalRequestActivityType> VocationalRequestActivityTypes { get;
            set; }

        #endregion
    }
}
