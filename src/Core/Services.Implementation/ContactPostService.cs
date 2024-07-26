using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ContactPostService(IContactPostRepository contactPostRepository): IContactPostService
    {

        public string Add(string fullName, string email, string subject, string content)
        {
            var post = new ContactPost
            {
                FullName = fullName,
                Email = email,
                Subject = subject,
                Content = content
            };

            return "Muraciet qebul olundu.";
        }
    }
}
