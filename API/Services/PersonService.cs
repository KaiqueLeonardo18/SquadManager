using Common;
using Repository.Entity;
using Repository;

namespace API.Services
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public int AddPerson(PersonModel model)
        {
            PersonEntity entity = new PersonEntity()
            {
                UserName = model.Username,
                Email = model.Email
            };

            return _personRepository.Add(entity);
        }

        public void UpdatePerson(PersonModel model)
        {
            PersonEntity entity = new PersonEntity()
            {
                Id = model.Id,
                UserName = model.Username,
                Email = model.Email
            };

            _personRepository.Update(entity);
        }
    }
}
