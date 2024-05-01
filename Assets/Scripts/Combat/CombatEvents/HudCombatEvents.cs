using Game.Data;
using UnityEngine.Events;

namespace Game.Combat
{
    public class UpdateEnemyData : UnityEvent<EnemyDto> { }
    public class UpdatePlayerData : UnityEvent<PlayerDto> { }
    public class HudCombatEvents 
    {
        public static readonly UpdateEnemyData onUpdateEnemyData = new UpdateEnemyData();
        public static readonly UpdatePlayerData onUpdatePlayerData = new UpdatePlayerData();
    }
}