using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BlogPosts
{
    public class AddBlogPostRequestDto
    {
        public required string Title { get; set; }
        public required string Body { get; set; }
        public required string ImagePath { get; set; }
        
    }
    public class AddBlogPostResponseDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Body { get; set; }
        public required string ImagePath { get; set; }

    }
}
