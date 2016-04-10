﻿module BasicControlsTest

open FsCheck
open FsCheck.NUnit
open Gacho.Controls
open System.IO
open System.Web.UI
open NUnit.Framework
open FsUnit

type PropertyAttribute = FsCheck.NUnit.PropertyAttribute
type Text = Gacho.Controls.Text

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

[<Test>]
let ``Rendering of LiteralControl with null Text renders empty Text`` () =
    use control = new Text()
    control.Value <- null
    renderControl control |> should equal ""

[<Test>]
let ``Rendering of LiteralControl without setting Text renders empty Text`` () =
    use control = new Text()
    renderControl control |> should equal ""