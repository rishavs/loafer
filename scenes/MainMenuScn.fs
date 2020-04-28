namespace MyGame

module MainMenuScene =
    open Love

    type Resources = { 
        scene   : AvailableScenes
    }
    
    // constants and static resources are kept here
    let resources = { 
        scene   = MainMenuScn
    }

    type Model =
        { text: string }

    let mutable model: Model = {
        text = "Menu model"
    }

    let update (data: Model, res: Resources, dt) =
        data

    let draw (data: Model) =
        Graphics.Print("Main Menu Scene", 10.0f, 200.0f)

