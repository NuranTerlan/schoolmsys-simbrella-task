using MediatR;

namespace SchoolManagementSystem.Application.Wrappers
{
    public interface IRequestHandlerWrapper<in TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
        where TIn : IRequestWrapper<TOut>
    {
        
    }
}