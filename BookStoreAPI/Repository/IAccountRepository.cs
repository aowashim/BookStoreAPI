using BookStoreAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStoreAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUp signUpModel);
        Task<string> LoginAsync(SignIn signModel);
    }
}
