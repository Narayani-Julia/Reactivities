using System;
using System.Reflection.Metadata.Ecma335;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
            //For DTO: context.Activities.Include(a => a.AssignedTeacher).First(i => i.Id.ToString()==request.Id);
            var activity = await context.Activities.FindAsync([request.Id], cancellationToken);
            if (activity == null)
            {
                //we are not able to return HTTP errors like return NotFound();
                throw new Exception("Activity Not Found");
            }
            return activity;
            //Method 2:
            //deferred execution
            //var activity1 = context.Activities.ToList();
            //In the Controller function after the mediator calls this: 
            //return Ok(stocks);
        }
    }
}
