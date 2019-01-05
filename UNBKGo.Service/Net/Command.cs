namespace UNBKGo.Service.Net
{
    public enum Command
    {
        // Client --> Server
        Identify,
        Ready,

        // Server --> Client
        Sync,
        StartExambro,
        SequentialConfig,
        TurnOff,
    }
}
