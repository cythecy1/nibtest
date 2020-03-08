using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Career
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string RoleDescription { get; set; }
        public string[] RoleTags { get; set; }
        public string SkillsDescription { get; set; }
        public string BenefitsDescription { get; set; }
        public int LocationId { get; set; }
        public bool Active { get; set; }
    }
}
