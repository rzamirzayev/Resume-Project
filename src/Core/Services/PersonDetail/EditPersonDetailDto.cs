using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PersonDetail
{
    public class EditPersonDetailDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public byte Experience { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Location { get; set; }
        public  string? Bio { get; set; }
        public  string? Fax { get; set; }
        public string? Website { get; set; }
    }
}
