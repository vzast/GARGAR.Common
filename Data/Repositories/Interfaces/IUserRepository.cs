
using Shared.DTO;

namespace Data.Repositories.Interfaces
{
    internal interface IUserRepository
    {
        public Task SignUp(UserRegistrationDTO request);
    }
}
