using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SkillPosts
{
    public class EditSkillPostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
    }
    public class EditSkillGroupDto
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public required string Name { get; set; }
    }
    public class EditSkillTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
