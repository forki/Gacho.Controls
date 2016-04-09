namespace Gacho.Controls

open System.Web.UI

type Literal () =
    inherit Control ()
    override this.Render writer =
        writer.Write "Test"
