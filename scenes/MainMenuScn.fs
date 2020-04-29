namespace MyGame

module MainMenuScene =
    open Love
    // update the model with the keys pressed by end user
    let handleKeyInput(data: Model, res:Resources,  dt, key, scode, isRepeat) = 
        data

    // update the model with the mouse button pressed by end user
    let handleMouseInput (data: Model) = 
        data

    // update the model with game mechanics
    let handleMechanics (data: Model, res: Resources, dt): Model =
        data

    // generate display list for this scene
    let genDisplayList (data: Model, res: Resources): DisplayList =

        let mutable scnDisplayList: DisplayList = {
            bgLayer                 = Seq.empty
            objInteractiveLayer     = Seq.empty
            objNonInteractiveLayer  = Seq.empty
            uiInteractiveLayer      = Seq.empty
            uiNonInteractiveLayer   = Seq.empty
            debugLayer              = Seq.empty
        }

        let text: Entity = EnText( value = "Main Menu Scene", x = 10.0f, y = 150.0f )
        scnDisplayList.uiNonInteractiveLayer <- Seq.append scnDisplayList.uiNonInteractiveLayer [text]

        scnDisplayList

