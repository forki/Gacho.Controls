module BasicControlsTest

open FsCheck
open FsCheck.NUnit
open Gacho.Controls
open System.IO
open System.Web.UI

let renderControl (ctrl : #Control) =
    use textWriter = new StringWriter()
    use writer = new HtmlTextWriter(textWriter)
    ctrl.RenderControl (writer)
    textWriter.ToString()

[<Property>]
let ``Rendering of LiteralControl with non null Text renders the same Text`` (text : NonNull<string>) =
    use control = new Text()
    control.Value <- text.Get
    renderControl control = text.Get

[<Property>]
let ``Rendering of LiteralControl with null Text renders empty Text`` () =
    use control = new Text()
    control.Value <- null
    renderControl control = ""

[<Property>]
let ``Rendering of LiteralControl without setting Text renders empty Text`` () =
    use control = new Text()
    renderControl control = ""