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
      let inputKeys = access.inputs.keys () |> JSI.toSeq
      let inputs = inputKeys |> Seq.map access.inputs.get
      let inputNames = inputs |> Seq.map (fun i -> match i.name with
                                                   | None -> "<>"
                                                   | Some n -> n) |> String.concat ","
      Connection access, Cmd.ofMsg (Inputs inputNames)
  | MIDIError _ -> 
      model, Cmd.none
  | Inputs s -> 
      InputNames s, Cmd.none
