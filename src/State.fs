module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import
open Fable.Import.Browser
open WebMIDI
open Types

let init () =
  NoAccess, Cmd.ofPromise MIDI.requestAccess [Sysex true] MIDIAccess MIDIError

let update msg model =
  match msg with
  | MIDIAccess access -> 
      let inputValues = access.inputs.values () |> JSI.toSeq
      let input = inputValues |> Seq.tryFind (fun i -> i.name.Value = "MPKmini2") 
      Access access, Cmd.ofMsg (SelectedInput input)
  | MIDIError _ -> 
      model, Cmd.none
  | SelectedInput i -> 
      Input i, Cmd.none
