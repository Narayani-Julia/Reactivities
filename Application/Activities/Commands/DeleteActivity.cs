using System;
using MediatR;
using Persistance;

namespace Application.Activities.Commands;

public class DeleteActivity
{
    public class Command : IRequest
    {
        public required string Id { get; set; }
    }
    //Putting the variable in the parameter here is basically passing the parameter to the constructor
    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.Id], cancellationToken) ??
                throw new Exception("Cannot find activity");
            //remove is not an async function
            context.Remove(activity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
