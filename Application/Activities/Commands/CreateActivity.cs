using System;
using Domain;
using MediatR;
using Persistance;

namespace Application.Activities.Queries;

public class CreateActivity
{
    public class Command : IRequest<string>
    {
        public required Activity Activity { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            // We don't need the async activity for this. AddAsync is only used for a specific case, you can look at AddAsync's documentation for this
            context.Activities.Add(request.Activity);
            //Only when the next line is executed is it actually saved to the database
            await context.SaveChangesAsync(cancellationToken);
            return request.Activity.Id.ToString();
        }
    }
}
