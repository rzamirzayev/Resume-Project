using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SkillPosts
{
    public class SkillPostGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
    }
    public class SkillGroupGetAllDto
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public required string Name { get; set; }
    }

    public class SkillTypeGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
