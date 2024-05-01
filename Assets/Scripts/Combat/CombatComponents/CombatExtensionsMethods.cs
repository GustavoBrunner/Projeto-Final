namespace Game.Combat.ExtensionsMethods
{
    public static class CombatExtensionsMethods 
    {
        public static float CalculateNextAttackResult(this CombatController @this, float hp, float damage )
        {
            return hp - damage;
        }
    }
}