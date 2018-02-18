using System;

namespace Shikana.Game.Logic.Players.StoragePiles
{
    public class InvalidStoragePileException : Exception
    {
        public InvalidStoragePileException(int index) : base(String.Format("Invalid Storage Pile at index: {0}", index))
        {

        }
    }
}
