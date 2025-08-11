using System;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers;
//Controller: Used to query the data from the database and return it to the client

//Passing in a variable like this is basically defining the contructor like this
//Referencing the basic structure of a controller that always has specific properties
public class ActivitiesController(IMediator mediator) : BaseApiController
{
    //HttpEndpoints will be here:
    //async is good coz the db is async
    //keep the return type in the actionResult
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        //Without Mediator: return await context.Activities.ToListAsync();
        return await mediator.Send(new GetActivityList.Query());
    }

    //This id will be replaced with whatever is passed in the parameter with the same name
    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        //Without Mediator:
        // var activity = await context.Activities.FindAsync(id);
        // if (activity == null) return BadRequest(); //can also return notFound();
        // return activity;
        //With Mediator:
        return await mediator.Send(new GetActivityDetails.Query { Id = id });
    }
}

//localhost:5001/api/activities