using Common;

namespace API.Services
{
    public interface IPersonService
    {
        int AddPerson(PersonModel model);

        void UpdatePerson(PersonModel model);
    }
}
