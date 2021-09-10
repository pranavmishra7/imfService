using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamodel.models
{
    public class InsuranceCategory
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<InsurancePlan> InsurancePlans { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
