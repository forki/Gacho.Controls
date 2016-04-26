namespace Gacho.Controls.Html

open Gacho.Controls.Helpers
open System
open System.Web.UI

[<AbstractClass>]
type HtmlControl(tagName) = 
    inherit Control()
    abstract AddAttributesToRender : HtmlTextWriter -> HtmlTextWriter
    abstract RenderBeginTag : HtmlTextWriter -> HtmlTextWriter
    
    override this.RenderBeginTag(writer) = 
        writer
        |> this.AddAttributesToRender
        |> HtmlTextWriter.renderBeginTag tagName
    
    abstract RenderContents : HtmlTextWriter -> HtmlTextWriter
    abstract RenderEndTag : HtmlTextWriter -> HtmlTextWriter
    override this.RenderEndTag(writer) = writer |> HtmlTextWriter.renderEndTag
    override this.Render writer = 
        writer
        |> this.RenderBeginTag
        |> this.RenderContents
        |> this.RenderEndTag
        |> ignore

[<AbstractClass>]
type HeadHtmlControl(tagName) = 
    inherit HtmlControl(tagName)

[<AbstractClass>]
type ContentHtmlControl(tagName) = 
    inherit HtmlControl(tagName)

[<AbstractClass>]
type StyledHtmlControl(tagName) as this = 
    inherit HtmlControl(tagName)
    let vs = this.ViewState
    member this.Class 
        with get () : string = vs |> ViewState.getWithDefault "Class" null
        and set (value : string) = 
            vs
            |> ViewState.set "Class" value
            |> ignore
    override this.AddAttributesToRender(writer) = 
        let addClass = 
            match this.Class with
            | value when String.IsNullOrEmpty value -> id
            | value -> HtmlTextWriter.addAttribute "class" value
        let addId =
            match this.ID with
            | value when String.IsNullOrEmpty value -> id
            | value -> HtmlTextWriter.addAttribute "id" value
        writer |> addId |> addClass

[<AbstractClass>]
type StructuralHtmlControl(tagName) = 
    inherit StyledHtmlControl(tagName)

[<AbstractClass>]
type TextHtmlControl(tagName) = 
    inherit StyledHtmlControl(tagName)
