using System;
using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers;
//Controller: Used to query the data from the database and return it to the client

//Passing in a variable like this is basically defining the contructor like this
//Referencing the basic structure of a controller that always has specific properties
public class ActivitiesController() : BaseApiController
{
    //HttpEndpoints will be here:
    //async is good coz the db is async
    //keep the return type in the actionResult
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }

    //This id will be replaced with whatever is passed in the parameter with the same name
    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
        return await Mediator.Send(new CreateActivity.Command { Activity = activity });
    }
    [HttpPut]
    public async Task<ActionResult> Edit(Activity activity)
    {
        await Mediator.Send(new EditActivity.Command { Activity = activity });
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        await Mediator.Send(new DeleteActivity.Command { Id = id });
        return Ok();
    }
}

//localhost:5001/api/activities