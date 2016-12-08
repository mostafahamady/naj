using Naj.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naj.Entity
{
    [Table("Baladi.RequestSubmitterInfo")]
    public class RequestSubmitterInfo : IEntity<Guid>
    {
        #region Constructors

        public RequestSubmitterInfo()
        {
            VocationalRequests = new HashSet<VocationalRequest>();
        }

        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(500)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string IdentityNumber { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }
        public int? IdentityTypeId { get; set; }
        public DateTime? IdentityIssuanceDate { get; set; }
        public DateTime? IdentityExpiredDate { get; set; }
        public int? GenderId { get; set; }
        public int? NationalityId { get; set; }

        [StringLength(50)]
        public string IdentityIssuancePalce { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string SecondName { get; set; }

        [StringLength(50)]
        public string ThirdName { get; set; }

        [StringLength(50)]
        public string FamilyName { get; set; }

        [Required]
        public long InvestorId { get; set; }
        #endregion

        #region Navigations

        public virtual ICollection<VocationalRequest> VocationalRequests { get; set; }

        #endregion
    }
}
