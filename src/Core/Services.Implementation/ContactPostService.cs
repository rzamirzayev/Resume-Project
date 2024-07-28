//using Domain.Entities;
//using Repositories;

//namespace Services.Implementation
//{
//    public class ContactPostService(IContactPostRepository contactPostRepository) : IContactPostService
//    {

//        public async Task<string> Add(string fullName, string email, string subject, string content)
//        {
//             var post = new ContactPost
//             {
//                FullName = fullName,
//                Email = email,
//                Subject = subject,
//                Content = content
//              };

//            return "Muraciet qebul olundu.";
//        }
//    }
//}
using Domain.Entities;
using Repositories;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ContactPostService : IContactPostService
    {
        private readonly IContactPostRepository _contactPostRepository;

        public ContactPostService(IContactPostRepository contactPostRepository)
        {
            _contactPostRepository = contactPostRepository;
        }

        public async Task<string> Add(string fullName, string email, string subject, string content)
        {
            var post = new ContactPost
            {
                FullName = fullName,
                Email = email,
                Subject = subject,
                Content = content
            };

            await _contactPostRepository.AddAsync(post); 
            await _contactPostRepository.SaveAsync(); 

            return "Muraciet qebul olundu.";
        }
    }
}

