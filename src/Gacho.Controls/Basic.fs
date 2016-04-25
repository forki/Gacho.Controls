namespace Gacho.Controls

open Helpers
open System
open System.ComponentModel
open System.Web
open System.Web.UI

type TextEncoding = 
    | Raw=0
    | Html=1

[<DefaultProperty("Value")>]
[<ToolboxData(@"<{0}:Text runat=""server"" Value="""" />")>]
type Text() as this = 
    inherit Control()
    let vs = this.ViewState
    
    [<Description("Gets or sets the text value")>]
    [<DefaultValue("")>]
    member this.Value 
        with get () = vs |> ViewState.getWithDefault "Text" null
        and set (value : string) = 
            vs
            |> ViewState.set "Text" value
            |> ignore
    
    [<Description("Gets or sets the text encoding")>]
    [<DefaultValue(typeof<TextEncoding>, "Raw")>]
    member this.Encoding 
        with get () = vs |> ViewState.getWithDefault "Encoding" TextEncoding.Raw
        and set (value : TextEncoding) = 
            vs
            |> ViewState.set "Encoding" value
            |> ignore
    
    override this.Render writer = 
        match this.Value with
        | text when not <| isNull text -> 
            let txt = 
                match this.Encoding with
                | TextEncoding.Html -> HttpUtility.HtmlEncode text
                | _ -> text
            writer
            |> HtmlTextWriter.write txt
            |> ignore
        | _ -> ()
