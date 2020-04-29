namespace MyGame

module IntroScene =
    open Love

    type Resources = { 
        scene   : AvailableScenes
    }
    
    // constants and static resources are kept here
    let resources = { 
        scene   = MainMenuScn
    }
    type Model =
        { text: string ; counter: int }

    let mutable model: Model = {
        text = "Intro model"
        counter = 0
    }

    let update (data: Model, res: Resources, dt) =
        {
        text = "Intro model"
        counter = data.counter + 1
        }

    let draw (data: Model) =
        Graphics.Print("Intro Scene " + string data.counter, 10.0f, 200.0f)
        