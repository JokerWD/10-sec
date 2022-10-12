using UnityEngine;

namespace TenEnemy
{
    public abstract class Shell : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D shellRigidbody2D;
        [SerializeField] private float speed;
        [SerializeField] protected int timeToDeath;
        public Vector2 MoveDirection { private get; set; }
        
        protected void SetDirection()
        {
            MoveDirection *= speed;
            shellRigidbody2D.velocity = new Vector2(MoveDirection.x, MoveDirection.y);
        }
    }
}