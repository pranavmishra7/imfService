using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamodel.models
{
    public class InsurancePlan
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("InsuranceCategory")]
        public Guid InsuranceCategoryId { get; set; }
        public InsuranceCategory InsuranceCategory { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public virtual InsuranceDetailsModel InsuranceDetails {get; set;}
    }
}
