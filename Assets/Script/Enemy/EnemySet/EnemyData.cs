using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace TenEnemy
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Gameplay/Enemy")]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public EnemyType EnemyType { get; private set; }
        [field: SerializeField] public float FireRate { get; private set; }
        [field: SerializeField] public float Range { get; private set; }
        [field: SerializeField] public AnimatorController _animator { get; private set; }
        [field: SerializeField] public Sprite _enemySprite { get; private set; }
    }
}
