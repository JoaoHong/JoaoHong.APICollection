using JoaoHong.APICollection.Domain.DTO;
using JoaoHong.APICollection.Domain.Entities;

namespace JoaoHong.APICollection.Domain.Port.Application.Services
{
    public interface IUserService
    {
        Task<GenericResponse> CreateUser(Users model);
    }
}
