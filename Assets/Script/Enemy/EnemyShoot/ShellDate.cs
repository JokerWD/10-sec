using UnityEngine;

namespace TenEnemy
{
    [CreateAssetMenu(fileName = "Shell", menuName = "Gameplay/Shell")]
    public class ShellDate : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int TimeToDeath { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }

    }
}