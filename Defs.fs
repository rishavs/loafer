namespace MyGame

open Love
open System.Collections.Generic

// ------------------------------------------------------
// Shared types and definitions go here
// ------------------------------------------------------
type AvailableScenes =
    | MainMenuScn
    | GameScn

type BtnState =
    | Default of Color
    | Hover of Color
    | Click of Color

type Entity =
    | EnText of value : string * x: float32 * y: float32 
    | EnSprite of texture: Love.Texture * x: float32 * y: float32 
    | EnBtn of width: float32 * height : float32 * btnState : BtnState * x: float32 * y: float32

type DrawableEntities = {
    mutable BgLayer  : Dictionary<string, Entity> 
    mutable ObjLayer : Dictionary<string, Entity>  
    mutable UiLayer  : Dictionary<string, Entity> 
    mutable DbgLayer : Dictionary<string, Entity> 
} 

type Resources = { 
    Scene   : AvailableScenes
    Speed   : float32
    Img     : Image
}

type Model = { 
    mutable CurrentScene: AvailableScenes
    mutable Counter: int 
    mutable BallPos: Vector2
    mutable MainMenuStartBtnState: BtnState
    mutable MainMenuSettingsBtnState: BtnState
    mutable MainMenuExitBtnState: BtnState
}

module Data = 
    // ------------------------------------------------------
    // Constants and statis resources are declared here
    // ------------------------------------------------------
    let Res = { 
        Scene   = GameScn
        Speed   = 300.0f
        Img     = Graphics.NewImage "assets/red_ball.png"
    }    

    // ------------------------------------------------------
    // Mutable game state goes in here
    // ------------------------------------------------------
    let ResetModel: Model = {
        CurrentScene                = MainMenuScn 
        Counter                     = 0
        BallPos                     = Vector2(300.0f, 300.0f)
        MainMenuStartBtnState       = Default (Color.AliceBlue) 
        MainMenuSettingsBtnState    = Default (Color.AliceBlue)
        MainMenuExitBtnState        = Default (Color.AliceBlue)
    }
    let mutable State = ResetModel 
    
    // ------------------------------------------------------
    // Mutable display list goes in here
    // ------------------------------------------------------
    let DisplayList = {
        BgLayer  = Dictionary<string, Entity>()  
        ObjLayer = Dictionary<string, Entity>()  
        UiLayer  = Dictionary<string, Entity>() 
        DbgLayer = Dictionary<string, Entity>() 
    } 
    
    // indexes for faster lookup of interactive elements
    let entityClickable = seq<string>
    let entityHoverable = seq<string>


