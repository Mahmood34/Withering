using Fluent;

/// <summary>
/// Here we demonstrate OnStart and OnFinish
/// These two methods are a convenient way to run code before and after the conversation 
/// </summary>
public class Conversation1 : FluentScript
{
    public override void OnStart() { PlayerManager.instance.player.playerController.canMove = false; }
    public override void OnFinish() { PlayerManager.instance.player.playerController.canMove = true; }

    public override FluentNode Create()
    {
        return Yell("Now you can't move while I talk!");
    }
}
