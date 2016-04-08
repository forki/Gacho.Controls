// include Fake lib
#r @"packages/FAKE/tools/FakeLib.dll"
open Fake

// Properties
let buildSrcDir = "./buildSrc/"
let buildTestDir = "./buildTest/"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [ buildSrcDir; buildTestDir ]
)

Target "BuildSrcApp" (fun _ ->
    !! "src/**/*.fsproj"
    |> MSBuildRelease buildSrcDir "Build"
    |> Log "AppBuild-Output: "
)

Target "BuildTestApp" (fun _ ->
    !! "tests/**/*.fsproj"
    |> MSBuildRelease buildTestDir "Build"
    |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    !! (buildTestDir + "/Gacho.Controls.Tests.dll")
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true
             Domain = NUnitDomainModel.NoDomainModel 
             Framework = "net-4.5"
             OutputFile = buildTestDir + "TestResults.xml" })
)

Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

// Dependencies
"Clean"
    ==> "BuildSrcApp"
    ==> "BuildTestApp"
    ==> "Test"
    ==> "Default"

// start build
RunTargetOrDefault "Default"