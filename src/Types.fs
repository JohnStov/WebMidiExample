module App.Types

open WebMIDI

type Msg =
  | MIDIConnected of IMIDIAccess
  | MIDIError of exn
  | Inputs of string


type Model = 
  | NoConnection
  | Connection of IMIDIAccess
  | InputNames of string