using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.BlogPosts;
using Services.PersonDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    class PersonDetailService : IPersonDetailService
    {
        private readonly IPersonDetailRepository personDetailRepository;

        public PersonDetailService(IPersonDetailRepository personDetailRepository)
        {
            this.personDetailRepository = personDetailRepository;
        }
        public async Task<AddPersonDetailResponseDto> AddAsync(AddPersonDetailResponseDto model, CancellationToken cancellationToken = default)
        {
            var entity = new Person { FullName = model.FullName, Experience = model.Experience, DateOfBirth = model.DateOfBirth,Location=model.Location,Bio=model.Bio,Fax=model.Fax,Website=model.Website };
            await personDetailRepository.AddAsync(entity, cancellationToken);
            await personDetailRepository.SaveAsync(cancellationToken);

            return new AddPersonDetailResponseDto {Id=entity.Id, FullName = entity.FullName, Experience = entity.Experience, DateOfBirth = entity.DateOfBirth, Location = entity.Location, Bio = entity.Bio, Fax = entity.Fax, Website = entity.Website };
        }

        public async Task<EditPersonDetailDto> EditAsync(EditPersonDetailDto model, CancellationToken cancellationToken = default)
        {
            var entity = await personDetailRepository.GetAsync(m => m.Id == model.Id, cancellationToken);
            entity.Id= model.Id;
            entity.FullName = model.FullName;
            entity.Experience = model.Experience;
            entity.DateOfBirth = model.DateOfBirth;
            entity.Location = model.Location;
            entity.Bio = model.Bio;
            entity.Fax = model.Fax;
            entity.Website = model.Website;

            personDetailRepository.Edit(entity);
            await personDetailRepository.SaveAsync(cancellationToken);

            return model;
        }

        public async Task<IEnumerable<PersonDetailGetAllDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var data = await personDetailRepository.GetAll()
    .Select(m => new PersonDetailGetAllDto
    {
        Id = m.Id,
        FullName = m.FullName,
        Experience = m.Experience,
        DateOfBirth = m.DateOfBirth,
        Location = m.Location,
        Bio = m.Bio,
        Fax = m.Fax,
        Website=m.Website
    })
    .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<EditPersonDetailDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var personDetail = await personDetailRepository.GetAsync(b => b.Id == id, cancellationToken);
            if (personDetail == null)
            {
                return null;
            }

            return new EditPersonDetailDto
            {
                Id = personDetail.Id,
                FullName = personDetail.FullName,
                Experience = personDetail.Experience,
                DateOfBirth = personDetail.DateOfBirth,
                Location = personDetail.Location,
                Bio = personDetail.Bio,
                Fax = personDetail.Fax,
                Website=personDetail.Website
            };
        }
    }
}
