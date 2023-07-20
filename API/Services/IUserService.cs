using Common;

namespace API.Services
{
    public interface IUserService
    {
        void AddUser(UserModel model);

        void UpdateUser(UserModel model);
    }
}
