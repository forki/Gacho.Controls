namespace Gacho.Controls.Html.Inline

open Gacho.Controls.Helpers
open Gacho.Controls.Html
open System
open System.ComponentModel
open System.Web
open System.Web.UI

[<DefaultProperty("Text")>]
[<ToolboxData(@"<{0}:Span runat=""server"" Text="""" />")>]
type Span() as this = 
    inherit TextHtmlControl("span")
    let vs = this.ViewState
    
    [<Description("Gets or sets the text value")>]
    [<DefaultValue("")>]
    member this.Text 
        with get () = vs |> ViewState.getWithDefault "Text" String.Empty
        and set (value : string) = 
            vs
            |> ViewState.set "Text" value
            |> ignore
    
    override this.RenderContents writer = 
        let renderText =  HtmlTextWriter.write <| HttpUtility.HtmlEncode this.Text
        writer |> renderText
