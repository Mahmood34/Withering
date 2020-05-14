using Fluent;

public abstract class MyFluentDialogue : FluentScript
{
    public override void OnFinish() { PlayerManager.instance.player.playerController.canMove = true; }
    public override void OnStart() { PlayerManager.instance.player.playerController.canMove = false; }
}
