namespace MyGame

module GameScene =
    open Love
    
    // update the model with the keys pressed by end user
    let handleKeyInput(data: Model, res: Resources, dt, key, scode, isRepeat) = 
        // data
        let mutable x = data.ballPos.X  
        let mutable y = data.ballPos.Y

        match key with
        | KeyConstant.W -> 
            y <- y - (res.speed * dt * 5.0f) 
        | KeyConstant.D ->
            x <- x + (res.speed * dt * 5.0f) 
        | KeyConstant.S ->
            y <- y + (res.speed * dt * 5.0f) 
        | KeyConstant.A ->
            x <- x - (res.speed * dt * 5.0f) 
        | _ -> ()

        { data with ballPos = Vector2(x,y)}

    // update the model with the mouse button pressed by end user
    let handleMouseInput (data: Model) = 
        data

    // update the model with game mechanics
    let handleMechanics (data: Model, res: Resources, dt): Model =
        // data
        let x = data.ballPos.X
        let x = if Keyboard.IsDown(KeyConstant.Right) then x + (res.speed * dt) else x
        let x = if Keyboard.IsDown(KeyConstant.Left) then x - (res.speed * dt) else x
        
        let y = data.ballPos.Y
        let y = if Keyboard.IsDown(KeyConstant.Down) then y + (res.speed * dt) else y
        let y = if Keyboard.IsDown(KeyConstant.Up) then y - (res.speed * dt) else y
      
        { data with ballPos = Vector2(x,y)}

    let genDisplayList (data: Model, res:Resources) =
        let mutable scnDisplayList: DisplayList = {
            bgLayer                 = Seq.empty
            objInteractiveLayer     = Seq.empty
            objNonInteractiveLayer  = Seq.empty
            uiInteractiveLayer      = Seq.empty
            uiNonInteractiveLayer   = Seq.empty
            debugLayer              = Seq.empty
        }

        let spr:Entity      = EnSprite(texture = res.img, x = data.ballPos.X, y = data.ballPos.Y)
        scnDisplayList.objNonInteractiveLayer <- Seq.append scnDisplayList.objNonInteractiveLayer [spr]

        let text: Entity    = EnText( value = "Game Scene", x = 10.0f, y = 150.0f )
        scnDisplayList.uiNonInteractiveLayer <- Seq.append scnDisplayList.uiNonInteractiveLayer [text]

        scnDisplayList
