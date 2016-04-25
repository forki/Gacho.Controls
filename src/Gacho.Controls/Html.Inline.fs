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
    inherit HtmlControl("span")
    let vs = this.ViewState
    
    [<Description("Gets or sets the text value")>]
    [<DefaultValue("")>]
    member this.Text 
        with get () = vs |> ViewState.getWithDefault "Text" String.Empty
        and set (value : string) = 
            vs
            |> ViewState.set "Text" value
            |> ignore
    
    member this.Class 
        with get () = vs |> ViewState.getWithDefault "Class" null
        and set (value : string) = 
            vs
            |> ViewState.set "Class" value
            |> ignore
    
    override this.AddAttributesToRender(writer) = 
        let thisWriter = 
            writer |> (match this.Class with
                       | null -> id
                       | text -> HtmlTextWriter.addAttribute "class" text)
        base.AddAttributesToRender(thisWriter)
    
    override this.RenderContents writer = writer |> HtmlTextWriter.write (HttpUtility.HtmlEncode this.Text)
