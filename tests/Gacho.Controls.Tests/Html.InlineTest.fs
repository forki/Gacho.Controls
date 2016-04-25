module Html

open FsCheck
open FsCheck.NUnit
open Gacho.Controls.Html.Inline
open System.IO
open System.Web.UI
open NUnit.Framework
open FsUnit
open System.Web
open BasicControlsTest

type PropertyAttribute = FsCheck.NUnit.PropertyAttribute

[<Property(Verbose = true)>]
let ``Rendering of Text control with Text renders the same Text`` (text : string) =
    use control = new Span()
    control.Text <- text
    renderControl control = ("<span>" + HttpUtility.HtmlEncode(text) + "</span>")