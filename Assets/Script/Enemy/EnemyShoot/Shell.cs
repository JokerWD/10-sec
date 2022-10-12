using UnityEngine;

namespace TenEnemy
{
    public abstract class Shell : MonoBehaviour
    {
        [SerializeField] private ShellDate date;
        [SerializeField] private Rigidbody2D shellRigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public Vector2 MoveDirection { private get; set; }
        
        protected int timeToDeath;

        private float _speed;

        private void Awake()
        {
            _speed = date.Speed;
            timeToDeath = date.TimeToDeath;
            spriteRenderer.sprite = date.Sprite;
        }

        protected void SetDirection()
        {
            MoveDirection *= _speed;
            shellRigidbody2D.velocity = new Vector2(MoveDirection.x, MoveDirection.y);
        }
    }
}