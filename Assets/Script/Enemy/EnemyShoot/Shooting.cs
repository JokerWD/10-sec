using TenSeconds;
using UnityEngine;

namespace TenEnemy
{
    public abstract class Shooting : MonoBehaviour, IShoot
    {
        [SerializeField] protected Transform fireTransform;
        
        public float FireRate { get; set; }
        
        protected float NextFireTime;
        protected Vector2 MoveDirection;
        
        public virtual void TryShoot()
        {
        }
    }
}