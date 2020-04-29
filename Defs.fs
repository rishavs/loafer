namespace MyGame

open Love

// ------------------------------------------------------
// Shared types and definitions go here
// ------------------------------------------------------
type AvailableScenes =
    | MainMenuScn
    | GameScn

type Entity =
    | EnText           of value : string           * x: float32 * y: float32 
    | EnSprite        of texture: Love.Texture    * x: float32 * y: float32 
    | EnAnimSprite
    | EnShape

type DisplayList = {
    mutable bgLayer                 : seq<Entity>
    mutable objInteractiveLayer     : seq<Entity>
    mutable objNonInteractiveLayer  : seq<Entity>
    mutable uiInteractiveLayer      : seq<Entity>
    mutable uiNonInteractiveLayer   : seq<Entity>
    mutable debugLayer              : seq<Entity>
}


type Resources = { 
    scene   : AvailableScenes
    speed   : float32
    img     : Image
}

type Model = { 
    mutable currentScene: AvailableScenes
    mutable counter: int 
    mutable ballPos: Vector2
}

module Data = 
    // ------------------------------------------------------
    // Constants and statis resources are declared here
    // ------------------------------------------------------
    let res = { 
        scene   = GameScn
        speed   = 300.0f
        img     = Graphics.NewImage "assets/red_ball.png"
    }    

    // ------------------------------------------------------
    // Mutable game state goes in here
    // ------------------------------------------------------
    let mutable state: Model = {
        currentScene = MainMenuScn 
        counter = 0
        ballPos = Vector2(300.0f, 300.0f)
    }


