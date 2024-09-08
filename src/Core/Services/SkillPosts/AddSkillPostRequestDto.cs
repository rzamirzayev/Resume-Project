using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SkillPosts
{
    public class AddSkillPostRequestDto
    {
        public required string Name { get; set; }
        public string SkillDesc { get; set; }
        public int SkillLevel { get; set; }
        public int GroupId { get; set; }
    }
    public class AddSkillPostResponseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string SkillDesc { get; set; }
        public int SkillLevel { get; set; }
        public int GroupId { get; set; }
    }
    
    public class AddSkillGroupRequestDto
    {
        public int TypeId { get; set; }
        public required string Name { get; set; }

        public string GroupDesc { get; set; }
    }
    public class AddSkillGroupResponseDto
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string GroupDesc { get; set; }

        public required string Name { get; set; }
    }
    public class AddSkillTypeRequestDto
    {
        public required string Name { get; set; }
    }
    public class AddSkillTypeResponseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
