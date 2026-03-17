using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Abstractions.Mediator
{
    public interface IRequest<out TResponse>
    {
    }

    public interface ICommand : IRequest<Unit>
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }

    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
