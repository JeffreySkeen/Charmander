namespace Charmander.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
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
                    DateCreaated = DateTime.Now
                    Description = String.Format("Service Number: {0}", i)
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
        
