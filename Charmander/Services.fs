namespace Charmander

open System
open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type Services = 
    {
        ID : int
        [<Required>]
        DateCreaated : DateTime
        [<Required>]
        Description : string   
    }