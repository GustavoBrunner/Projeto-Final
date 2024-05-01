using UnityEngine.Events;

namespace Game.Data
{
    public class UpdatePlayerData : UnityEvent<PlayerDto> { }

    public class DataEvents 
    {
        public static readonly UpdatePlayerData onUpdatePlayerData = new UpdatePlayerData();
    }
}