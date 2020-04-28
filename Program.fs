namespace MyGame

module Program =

    open Love

    [<EntryPoint>]
    let main argv =
        let config = BootConfig(WindowWidth = 800, WindowHeight = 600, WindowTitle = "My Awesome Game")
        Boot.Init config
        Boot.Run(Game.Runner())
        0 // return an integer exit code
