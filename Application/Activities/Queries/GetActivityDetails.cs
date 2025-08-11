using System;
using System.Reflection.Metadata.Ecma335;
using Domain;
using MediatR;
using Persistance;

namespace Application.Activities.Queries;

public class GetActivityDetails
{
    public class Query : IRequest<Activity>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
    {
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.Id], cancellationToken);
            if (activity == null)
            {
                //we are not able to return HTTP errors like return NotFound();
                throw new Exception("Activity Not Found");
            }
            return activity;


        }
    }

}
