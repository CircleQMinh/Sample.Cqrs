using Microsoft.Extensions.DependencyInjection;
using Sample.Cqrs.Application.Abstractions.Mediator;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Infrastructure.Mediator
{
    internal abstract class RequestHandlerWrapper
    {
        public abstract Task<object?> Handle(
            object request,
            IServiceProvider serviceProvider,
            CancellationToken cancellationToken);
    }

    internal class RequestHandlerWrapper<TRequest, TResponse> : RequestHandlerWrapper
        where TRequest : IRequest<TResponse>
    {
        public override async Task<object?> Handle(
            object request,
            IServiceProvider serviceProvider,
            CancellationToken cancellationToken)
        {
            var typedRequest = (TRequest)request;

            var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();

            var behaviors = serviceProvider
                .GetServices<IPipelineBehavior<TRequest, TResponse>>()
                .Reverse()
                .ToArray();

            RequestHandlerDelegate<TResponse> handlerDelegate = () =>
                handler.Handle(typedRequest, cancellationToken);

            foreach (var behavior in behaviors)
            {
                var next = handlerDelegate;
                handlerDelegate = () => behavior.Handle(typedRequest, cancellationToken, next);
            }

            var response = await handlerDelegate();
            return response;
        }
    }

    internal static class RequestHandlerWrapperCache
    {
        private static readonly ConcurrentDictionary<(Type RequestType, Type ResponseType), RequestHandlerWrapper> Cache = new();

        public static RequestHandlerWrapper Get(Type requestType, Type responseType)
        {
            return Cache.GetOrAdd((requestType, responseType), static key =>
            {
                var wrapperType = typeof(RequestHandlerWrapper<,>).MakeGenericType(key.RequestType, key.ResponseType);
                return (RequestHandlerWrapper)Activator.CreateInstance(wrapperType)!;
            });
        }
    }
}
