using System.Collections.Generic;

namespace Module4HW3.Entity
{
    public class TitleEntity
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public List<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
    }
}
