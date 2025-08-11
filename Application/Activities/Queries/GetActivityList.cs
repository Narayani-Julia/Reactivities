using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistance;

namespace Application.Activities.Queries;

public class GetActivityList
{
    //Mediator queries must be a class inside a class:
    public class Query : IRequest<List<Activity>> { }
    // Since the below IRequestHandler is an interface, so quick fix the required functions ya need 
    // Add the AppDbContext into the handler though
    public class Handler(AppDbContext context, ILogger<GetActivityList> logger) : IRequestHandler<Query, List<Activity>>
    {
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Delay(1000, cancellationToken);
                    logger.LogInformation($"Task {i} has completed");
                }
            }
            catch (System.Exception) {
                logger.LogInformation($"Task was cancelled");
            }
            //pass in the cancellation token here
            return await context.Activities.ToListAsync(cancellationToken);
        }
    }
}
