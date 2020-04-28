namespace MyGame

module GameScene =
    open Love

    type Resources = { 
        scene   : AvailableScenes
        speed   : float32
        img     : Image
    }
    type Model = { 
        pos     : Vector2
    }
    
    // constants and static resources are kept here
    let resources = { 
        scene   = GameScn
        speed   = 300.0f
        img     = Graphics.NewImage "assets/red_ball.png"
    }
    
    // mutable model data is kept here
    let mutable model: Model = {
        pos = Vector2(300.0f, 300.0f)
    }
    
    let update (data: Model, res: Resources, dt) =
        let x = data.pos.X
        let x = if Keyboard.IsDown(KeyConstant.Right) then x + (resources.speed * dt) else x
        let x = if Keyboard.IsDown(KeyConstant.Left) then x - (resources.speed * dt) else x
        
        let y = data.pos.Y
        let y = if Keyboard.IsDown(KeyConstant.Down) then y + (resources.speed * dt) else y
        let y = if Keyboard.IsDown(KeyConstant.Up) then y - (resources.speed * dt) else y
        { data with pos = Vector2(x,y)}

    let draw (data: Model) =
        Graphics.Print("Game Scene", 10.0f, 200.0f)
        Graphics.Draw(resources.img, data.pos.X, data.pos.Y)
