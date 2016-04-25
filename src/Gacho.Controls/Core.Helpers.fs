namespace Gacho.Controls

module Helpers =
    open System.Web
    open System.Web.UI

    module ViewState =
        let get<'a> key (vs : StateBag) =
            match vs.[key] with
            | :? 'a as value -> Some value
            | _ -> None

        let getWithDefault<'a> key defaultValue (vs : StateBag) =
            match vs |> get<'a> key with
            | Some value -> value
            | _ -> defaultValue

        let set key value (vs : StateBag) =
            vs.[key] <- value
            vs

    module HtmlTextWriter =
        let write (text : string) (writer : HtmlTextWriter) =
            writer.Write text
            writer

        let renderBeginTag (tagName : string) (writer : HtmlTextWriter) =
            writer.RenderBeginTag tagName
            writer

        let writeBeginTag (tagName : string) (writer : HtmlTextWriter) =
            writer.WriteBeginTag tagName
            writer

        let addAttribute (name : string) (value : string) (writer : HtmlTextWriter) =
            writer.AddAttribute(name, value)
            writer

        let writeAttribute (name : string) (value : string) (writer : HtmlTextWriter) =
            writer.WriteAttribute(name, value)
            writer

        let renderEndTag (writer : HtmlTextWriter) =
            writer.RenderEndTag ()
            writer

        let writeEndTag (tagName : string) (writer : HtmlTextWriter) =
            writer.WriteEndTag tagName
            writer