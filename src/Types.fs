module App.Types

open WebMIDI

type Msg =
  | MIDIConnected of IMIDIAccess
  | MIDIError of exn


type Model = {
    midiAccess: IMIDIAccess option
}
