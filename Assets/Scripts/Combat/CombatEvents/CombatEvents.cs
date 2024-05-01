using Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Combat
{

    public class CombatTimerEnded : UnityEvent { }
    public class CombatStarted : UnityEvent<EnemyTypes, CombatPhase> { }
    public class CombatCalled : UnityEvent<List<EnemyDto>, PlayerDto> { }
    public class CombatFinished : UnityEvent { }

    public class CircleClicked : UnityEvent<bool> { }


    public class CircleSkillPassed : UnityEvent<DamageTypes, float> { }
    public class CircleSkillMissed : UnityEvent<DamageTypes, float> { }

    public class TargetHitted : UnityEvent { }

    public class CombatEvents : MonoBehaviour
    {
        public static readonly CombatTimerEnded onCombatTimerEnded = new CombatTimerEnded();
        public static readonly CombatStarted onCombatStarted = new CombatStarted();
        public static readonly CombatFinished onCombatFinished = new CombatFinished();

        public static readonly CircleClicked onCircleClicked = new CircleClicked();

        public static readonly CircleSkillMissed onMissClick = new CircleSkillMissed();
        public static readonly CircleSkillPassed onPassSkill = new CircleSkillPassed();

        public static readonly CombatCalled onCombatCalled = new CombatCalled();

        public static readonly TargetHitted onTargetHitted = new TargetHitted();

    }
}