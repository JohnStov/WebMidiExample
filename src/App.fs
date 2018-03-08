module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Types
open App.State

importAll "../sass/main.sass"

open Fable.Helpers.React
open Fable.Helpers.React.Props

let root model dispatch =
    match model with
    | NoConnection _ -> div [] [str "No Connection"]
    | Connection _ -> div [] [str "Connected"]
    | Input i when i = None -> div [] [str "No Input found"]
    | Input i -> div [] [str (sprintf "Using input %s" i.Value.name.Value)]

open Elmish.React
open Elmish.Debug
open Elmish.HMR

// App
Program.mkProgram init update root
#if DEBUG
|> Program.withDebugger
|> Program.withHMR
#endif
|> Program.withReact "elmish-app"
|> Program.run
