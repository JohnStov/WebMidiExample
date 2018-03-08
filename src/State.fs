module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open Types

let init result =
  {value = 0}, Cmd.ofMsg Something

let update msg model =
  match msg with
  | Something -> { model with value = 1 }, Cmd.none
