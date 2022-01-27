using System;
using System.Collections.Generic;

namespace Module4HW3.Entity
{
    public class EmployeeEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int OfficeId { get; set; }
        public OfficeEntity Office { get; set; }
        public int TitleId { get; set; }
        public TitleEntity Title { get; set; }

        public List<EmployeeProjectEntity> EmployeeProjects { get; set; } = new List<EmployeeProjectEntity>();
    }
}
