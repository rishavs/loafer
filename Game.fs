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
                Data.State.CurrentScene <- MainMenuScn
            | KeyConstant.Number3 -> 
                Data.State.CurrentScene <- GameScn
            | _ -> ()            

            // handle scene specific keys 
            match Data.State.CurrentScene with
            | MainMenuScn -> 
                Data.State <- MainMenuScene.handleKeyInput(Data.State, Data.Res, Timer.GetAverageDelta(), key, scode, isRepeat)
            | GameScn  -> 
                Data.State <- GameScene.handleKeyInput(Data.State, Data.Res,  Timer.GetAverageDelta(), key, scode, isRepeat)

        override this.MouseReleased(x, y, btn, isTouch) = 
            ()

        override this.Update(dt: float32) =
            // TODO: Add your update logic here
            
            match Data.State.CurrentScene with 
            | MainMenuScn -> 
                Data.State  <- MainMenuScene.handleMechanics (Data.State, Data.Res, dt)
            | GameScn     -> 
                Data.State  <- GameScene.handleMechanics (Data.State, Data.Res, dt)

        override this.Draw() =
            // TODO: Add your drawing code here

            let displayList =
                match Data.State.CurrentScene with 
                | MainMenuScn -> MainMenuScene.genDisplayList (Data.State, Data.Res)
                | GameScn     -> GameScene.genDisplayList (Data.State, Data.Res)
           
            // if any debug info needs to be added do here
            let fpsText     = EnText( value = "FPS: " + string (Timer.GetFPS()), x = 10.0f, y = 0.0f )
            displayList.DbgLayer <- Seq.append displayList.DbgLayer [fpsText]

            let timeDeltaText = EnText( value = "FPS: " + string (Timer.GetAverageDelta()), x = 10.0f, y = 50.0f )
            displayList.DbgLayer <- Seq.append displayList.DbgLayer [timeDeltaText]

            let instrText   = EnText( value = "Press 1 for Intro, 2 for Main Menu, and 3 for Game Scenes", x = 10.0f, y = 100.0f )
            displayList.DbgLayer <- Seq.append displayList.DbgLayer [instrText]

            let renderLayer(entSeq: seq<Entity>) =
                entSeq |> Seq.iter (
                    fun ent ->
                        match ent with
                        | EnText (value, x, y)   -> Graphics.Print(value, x, y)
                        | EnSprite (texture, x, y) -> Graphics.Draw(texture, x, y)
                        | EnBtn (width, height, btnState, x, y) -> 
                            Graphics.Rectangle(DrawMode.Fill,  x, y, width, height)

                        //  add check for hover in this loop itself?
                    )                    

            renderLayer displayList.bgLayer
            renderLayer displayList.objNonInteractiveLayer
            renderLayer displayList.objInteractiveLayer
            renderLayer displayList.uiNonInteractiveLayer
            renderLayer displayList.uiInteractiveLayer
            renderLayer displayList.debugLayer

