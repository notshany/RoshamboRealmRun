using System;

internal class AIController
{
    internal AIController.RPSCharacter.RPS GetEnemyType()
    {
        throw new NotImplementedException();
    }

    internal class RPSCharacter
    {
        internal class RPS
        {
            public static RPS Scissors { get; internal set; }
            public static RPS Rock { get; internal set; }
            public static RPS Paper { get; internal set; }
        }
    }
}