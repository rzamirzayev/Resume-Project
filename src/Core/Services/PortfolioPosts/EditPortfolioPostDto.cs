﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PortfolioPosts
{
    public class EditPortfolioPostDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Desc { get; set; }
        public required string ImagePath { get; set; }
    }
}
