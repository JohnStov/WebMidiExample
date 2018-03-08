module App.Types

open WebMIDI

type Msg =
  | MIDIConnected of IMIDIAccess
  | MIDIError of exn
  | SelectedInput of IMIDIInput option


type Model = 
  | NoConnection
  | Connection of IMIDIAccess
  | Input of IMIDIInput option