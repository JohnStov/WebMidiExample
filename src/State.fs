module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import
open Fable.Import.Browser
open WebMIDI
open Types

let init result =
  {midiAccess = None}, Cmd.ofPromise MIDI.requestAccess [Sysex true] MIDIConnected MIDIError

let update msg model =
  match msg with
  | MIDIConnected access -> 
      window.alert "connected"
      { model with midiAccess = Some access}, Cmd.none
  | MIDIError ex -> 
      window.alert ex.Message
      model, Cmd.none
