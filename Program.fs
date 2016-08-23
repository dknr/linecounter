open System
open System.IO
open System.Linq

let linesInFile (lineFilter:string->bool) file = 
    file
    |> File.ReadLines
    |> Seq.where lineFilter
    |> Seq.length

let linesInPath (fileFilter:string->bool) (lineFilter:string->bool) path = 
    Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)
    |> Seq.where fileFilter
    |> Seq.map (linesInFile lineFilter)
    |> Seq.sum

let allFiles x = 
    true

let allLines x =
    true

[<EntryPoint>]
let main argv = 
    let searchDir = @"C:\TestDir"     // TODO
    let fileFilter = allFiles
    let lineFilter = allLines

    linesInPath fileFilter lineFilter searchDir
    |> printfn "%A"
    
    Console.ReadLine() |> ignore
    0 // return an integer exit code
