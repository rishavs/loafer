namespace MyGame

module Game =
    open Love

    type Model =
        { mutable currentScene: AvailableScenes }
        
    type Runner() as __ =
        inherit Scene()

        let model: Model = 
            { currentScene = IntroScn }

        override this.Update(dt: float32) =
            // TODO: Add your update logic here
            
            match model.currentScene with 
            | IntroScn    -> 
                IntroScene.model    <- IntroScene.update (IntroScene.model, IntroScene.resources, dt)
            | MainMenuScn -> 
                MainMenuScene.model <- MainMenuScene.update (MainMenuScene.model, MainMenuScene.resources, dt)
            | GameScn     -> 
                GameScene.model     <- GameScene.update (GameScene.model, GameScene.resources, dt)

            if Keyboard.IsDown(KeyConstant.Number1) then model.currentScene <- IntroScn
            if Keyboard.IsDown(KeyConstant.Number2) then model.currentScene <- MainMenuScn
            if Keyboard.IsDown(KeyConstant.Number3) then model.currentScene <- GameScn

        override this.Draw() =
            // TODO: Add your drawing code here

            match model.currentScene with 
            | IntroScn    -> IntroScene.draw IntroScene.model
            | MainMenuScn -> MainMenuScene.draw MainMenuScene.model
            | GameScn     -> GameScene.draw GameScene.model

            Graphics.Print("FPS: " + string (Timer.GetFPS()), 10.0f, 10.0f)
            Graphics.Print("Press 1 for Intro, 2 for Main Menu, and 3 for Game Scenes", 10.0f, 50.0f)
            Graphics.Print(string model.currentScene, 10.0f, 100.0f)
