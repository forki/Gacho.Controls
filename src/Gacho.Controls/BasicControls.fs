namespace Gacho.Controls

open System.ComponentModel
open System.Web.UI
open System.Web

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
        with get () = 
            match vs.["Text"] with
            | :? string as text -> text
            | _ -> null : string
        and set (value : string) = vs.["Text"] <- value

    [<Description("Gets or sets the text encoding")>]
    [<DefaultValue(typeof<TextEncoding>,"Raw")>] 
    member this.Encoding
        with get () = 
            match vs.["Encoding"] with
            | :? TextEncoding as encoding -> encoding
            | _ -> TextEncoding.Raw
        and set (value : TextEncoding) = vs.["Encoding"] <- value
    
    override this.Render writer = 
        match this.Value with
        | text when not (isNull text) -> 
            match this.Encoding with
            | TextEncoding.Html -> writer.Write (HttpUtility.HtmlEncode text)
            | _ -> writer.Write text
        | _ -> ()
