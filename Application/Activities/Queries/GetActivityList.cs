using System;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Activities.Queries;

public class GetActivityList
{
    //Mediator queries must be a class inside a class:
    public class Query : IRequest<List<Activity>> { }
    // Since the below IRequestHandler is an interface, so quick fix the required functions ya need 
    // Add the AppDbContext into the handler though
    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Activity>>
    {
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            //THis is repository Function
            //pass in the cancellation token here
            return await context.Activities.ToListAsync(cancellationToken);
            //Find based on primary key, firstOrDefault is checking everyvalue
            //Method 2:
            // var stock = context.Activities.Find(id);
            // if (stock == null)
            // {
            //     return NotFound();
            // }
            // return Ok(stock);
        }
    }
}
