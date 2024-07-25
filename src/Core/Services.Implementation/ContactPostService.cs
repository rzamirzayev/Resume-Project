using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ContactPostService : IContactPostService
    {
        private readonly DbContext db;

        public ContactPostService(DbContext db) {
            this.db = db;
        }
        public string Add(string fullName, string email, string subject, string content)
        {
            var post = new ContactPost
            {
                FullName = fullName,
                Email = email,
                Subject = subject,
                Content = content,
                CreatedAt = DateTime.Now
            };
            db.Set<ContactPost>().Add(post);
            db.SaveChanges();
            return "Muraciet qebul olundu.";
        }
    }
}
