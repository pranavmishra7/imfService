using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamodel.models
{
   public class InsuranceDetailsModel
    {
        [Key]
        public Guid InsurancePolicyId { get; set; }
        [ForeignKey("InsuranceCategory")]
        public Guid InsuranceCategoryId { get; set; }
        public virtual InsuranceCategory insuranceCategory { get; set; }
        [ForeignKey("InsurancePlan")]
        public Guid InsurancePlanId { get; set; }
        public virtual InsurancePlan insurancePlan { get; set; }
        public string insuranceProvider { get; set; }
        public string policyName { get; set; }
        public string sumAssured { get; set; }
        public int premiumPayingTerm { get; set; }
        public int policyTerm { get; set; }
        public string premiumPayingMode { get; set; }
    }
}
