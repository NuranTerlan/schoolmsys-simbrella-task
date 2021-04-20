using MediatR;

namespace SchoolManagementSystem.Application.Wrappers
{
    public interface IRequestWrapper<T> : IRequest<Response<T>>
    {
        
    }
}