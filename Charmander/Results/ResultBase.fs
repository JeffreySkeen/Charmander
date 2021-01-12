namespace Charmander.Result

type ResultBase =
    val ResultCode : int
    val ResultMessage : string
    new() = {
        ResultCode = 0
        ResultMessage = "Okay"
    }
    new(resultCode, resultMessage) = {
        ResultCode = resultCode
        ResultMessage = resultMessage
    }