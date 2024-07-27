using Domain.Entities;
using Repositories;

namespace Services.Implementation
{
    public class ContactPostService : IContactPostService
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
