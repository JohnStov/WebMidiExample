module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import
open Fable.Import.Browser
open WebMIDI
open Types

let init () =
  NoConnection, Cmd.ofPromise MIDI.requestAccess [Sysex true] MIDIConnected MIDIError

let update msg model =
  match msg with
  | MIDIConnected access -> 
      let inputValues = access.inputs.values () |> JSI.toSeq
      let input = inputValues |> Seq.tryFind (fun i -> i.name.Value = "MPKmini2") 
      Connection access, Cmd.ofMsg (SelectedInput input)
  | MIDIError _ -> 
      model, Cmd.none
  | SelectedInput i -> 
      Input i, Cmd.none
