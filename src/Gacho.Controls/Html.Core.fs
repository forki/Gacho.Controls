namespace Gacho.Controls.Html

open Gacho.Controls.Helpers
open System.Web.UI

[<AbstractClass>]
type HtmlControl(tagName) = 
    inherit Control()
    abstract AddAttributesToRender : HtmlTextWriter -> HtmlTextWriter
    
    override this.AddAttributesToRender(writer) = 
        writer |> (if not <| (isNull <| this.ID) then HtmlTextWriter.addAttribute "id" this.ID
                   else id)
    
    abstract RenderBeginTag : HtmlTextWriter -> HtmlTextWriter
    override this.RenderBeginTag(writer) = writer |> this.AddAttributesToRender |> HtmlTextWriter.renderBeginTag tagName
    abstract RenderContents : HtmlTextWriter -> HtmlTextWriter
    abstract RenderEndTag : HtmlTextWriter -> HtmlTextWriter
    override this.RenderEndTag(writer) = writer |> HtmlTextWriter.renderEndTag
    override this.Render writer = 
        writer
        |> this.RenderBeginTag
        |> this.RenderContents
        |> this.RenderEndTag
        |> ignore
