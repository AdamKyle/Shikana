using System;

namespace Shikana.Game.Logic.Game.PlayPiles
{
    public class InvalidPlayPileException : Exception
    {
        public InvalidPlayPileException(int index) : base(String.Format("Invalid Play Pile at index: {0}", index))
        {

        }
    }
}
