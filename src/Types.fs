module App.Types

open WebMIDI

type Msg =
  | MIDIAccess of IMIDIAccess
  | MIDIError of exn
  | NoInputMsg
  | SelectedInput of IMIDIInput


type Model = 
  | NoAccess
  | Access of IMIDIAccess
  | NoInput
  | Input of IMIDIInput