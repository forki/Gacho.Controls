namespace Gacho.Controls

open System.Web.UI

type Text () as this =
    inherit Control ()
    let vs = this.ViewState
    member this.Value 
        with get() : string = 
            match vs.["Text"] with 
            | :? string as text -> text                         
            | _ -> null
        and set(value : string) = 
            vs.["Text"] <- value
    override this.Render writer =
        match this.Value with
        | text when not (isNull text) -> writer.Write text
        | _ -> ()
