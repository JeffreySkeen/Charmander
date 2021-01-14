namespace Charmander.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.Text.Json
open System.Text.Json.Serialization
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Charmander
open Microsoft.AspNetCore.Cors
open Charmander.Result

[<ApiController>]
[<Route("API/ServiceController")>]
type ServicesController (logger : ILogger<ServicesController>) = 
    inherit ControllerBase()

    let mockServices : Charmander.Services[] = 
        [|
            for i in 0..99 ->
                {
                    ID = i
                    Description = String.Format("Service Number: {0}", i)
                    DateCreaated = DateTime.Now
                }
        |]

    [<HttpGet>]
    [<Route("GetServices")>]
    [<EnableCors("AllowAll")>]
    member __.Get() : Charmander.Services[] = mockServices

    [<HttpGet>]
    [<Route("GetServices/{pageNumber}/{pageSize}")>]
    [<EnableCors("AllowAll")>]
    member __.GetServices(pageNumber, pageSize) : GetServicesResult =
        new GetServicesResult(mockServices.Skip(pageNumber * pageSize).Take(pageSize).ToArray())      

    [<HttpGet>]
    [<Route("FindService/{serviceID}")>]
    [<EnableCors("AllowAll")>]
    member __.FindService(serviceID) : Charmander.Services = 
        mockServices.First(fun f -> f.ID.Equals(serviceID))

    [<HttpPost>]
    [<Route("CreateService")>]
    [<EnableCors("AllowAll")>]
    member __.CreateService([<FromBody>] service : Charmander.Services) : Charmander.Services =
        let rng = System.Random()
        {
            ID = rng.Next(100,200)
            Description = service.Description
            DateCreaated = service.DateCreaated
        }
