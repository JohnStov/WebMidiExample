module App.Types

open WebMIDI

type Msg =
  | MIDIAccess of IMIDIAccess
  | MIDIError of exn
  | SelectedInput of IMIDIInput option


type Model = 
  | NoAccess
  | Access of IMIDIAccess
  | Input of IMIDIInput option