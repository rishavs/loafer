namespace MyGame

module Game =
    open Love
        
    type Runner() as __ =
        inherit Scene()

        override this.Load() =
            Keyboard.SetKeyRepeat true

        override this.KeyPressed(key, scode, isRepeat) =
            // handle global keys
            match key with
            | KeyConstant.Escape -> Event.Quit(0)
            | KeyConstant.Number2 -> 
                Data.state.currentScene <- MainMenuScn
            | KeyConstant.Number3 -> 
                Data.state.currentScene <- GameScn
            | _ -> ()            

            // handle scene specific keys 
            match Data.state.currentScene with
            | MainMenuScn -> 
                Data.state <- MainMenuScene.handleKeyInput(Data.state, Data.res, Timer.GetAverageDelta(), key, scode, isRepeat)
            | GameScn  -> 
                Data.state <- GameScene.handleKeyInput(Data.state, Data.res,  Timer.GetAverageDelta(), key, scode, isRepeat)

        override this.MouseReleased(x, y, btn, isTouch) = 
            ()

        override this.Update(dt: float32) =
            // TODO: Add your update logic here
            
            match Data.state.currentScene with 
            | MainMenuScn -> 
                Data.state  <- MainMenuScene.handleMechanics (Data.state, Data.res, dt)
            | GameScn     -> 
                Data.state  <- GameScene.handleMechanics (Data.state, Data.res, dt)

        override this.Draw() =
            // TODO: Add your drawing code here

            let displayList =
                match Data.state.currentScene with 
                | MainMenuScn -> MainMenuScene.genDisplayList (Data.state, Data.res)
                | GameScn     -> GameScene.genDisplayList (Data.state, Data.res)
           
            // if any debug info needs to be added do here
            let fpsText     = EnText( value = "FPS: " + string (Timer.GetFPS()), x = 10.0f, y = 0.0f )
            displayList.debugLayer <- Seq.append displayList.debugLayer [fpsText]

            let timeDeltaText = EnText( value = "FPS: " + string (Timer.GetAverageDelta()), x = 10.0f, y = 50.0f )
            displayList.debugLayer <- Seq.append displayList.debugLayer [timeDeltaText]

            let instrText   = EnText( value = "Press 1 for Intro, 2 for Main Menu, and 3 for Game Scenes", x = 10.0f, y = 100.0f )
            displayList.debugLayer <- Seq.append displayList.debugLayer [instrText]

            let renderLayer(entSeq: seq<Entity>) =
                entSeq |> Seq.iter (
                    fun ent ->
                        match ent with
                        | EnText (value, x, y)   -> Graphics.Print(value, x, y)
                        | EnSprite (texture, x, y) -> Graphics.Draw(texture, x, y)
                        | _ -> ()
                    )                    

            renderLayer displayList.bgLayer
            renderLayer displayList.objNonInteractiveLayer
            renderLayer displayList.objInteractiveLayer
            renderLayer displayList.uiNonInteractiveLayer
            renderLayer displayList.uiInteractiveLayer
            renderLayer displayList.debugLayer

