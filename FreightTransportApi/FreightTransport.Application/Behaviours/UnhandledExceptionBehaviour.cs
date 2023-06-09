﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace FreightTransport.Application.Behaviours
{

  public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
  {

    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    { _logger = logger; }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
      try
      { return await next(); }
      catch (Exception ex)
      {
        var requestName = typeof(TRequest).Name;
        _logger.LogError(ex, "Aplication Request: Sucedio una excepción para el request {Name} {@Request}", requestName, request);
        throw;
      }
    }

  }

}
