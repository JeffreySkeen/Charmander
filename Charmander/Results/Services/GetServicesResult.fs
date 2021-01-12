namespace Charmander.Result

open Charmander

type GetServicesResult =
    inherit ResultBase

    val services : Services[]
    new(srvs) = {
        inherit ResultBase(); services = srvs
    }


