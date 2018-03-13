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

let handleMessage (msg: IMIDIMessageEvent) : unit =
    window.alert "MIDI message received"

let update msg model =
    match msg with
    | MIDIAccess access -> 
        let inputValues = access.inputs.values () |> JSI.toSeq
        let input = inputValues |> Seq.tryFind (fun i -> i.name.Value = "MPKmini2") 
        let newMsg = 
            match input with
            | None -> NoInputMsg
            | Some i -> (SelectedInput i)
        Access access, (Cmd.ofMsg newMsg)
    | MIDIError _ -> model, Cmd.none
    | NoInputMsg -> NoInput, Cmd.none
    | SelectedInput i -> Input i, Cmd.ofMsg (Start i)
    | Start i -> 
        i.onmidimessage <- handleMessage
        model, Cmd.none
