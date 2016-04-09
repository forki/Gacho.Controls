module BasicControlsTest

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
let ``Rendering of LiteralControl always generate Test`` () =
    use control = new Literal()
    renderControl control = "Test"