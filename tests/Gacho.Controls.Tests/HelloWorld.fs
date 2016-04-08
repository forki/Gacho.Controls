module Gacho.Controls.Test

open FsCheck.NUnit

[<Property>]
let ``Reverse of reverse of a list is the original list `` (xs:int list) =
  List.rev(List.rev xs) = xs