namespace MyGame

type AvailableScenes =
    | IntroScn
    | MainMenuScn
    | GameScn

type Entity =
    | Text              of value : string           * x: float32 * y: float32 * is_visible: bool
    | Sprite            of texture: Love.Texture    * x: float32 * y: float32 * is_visible: bool
    | AnimatedSprite
    | Shape