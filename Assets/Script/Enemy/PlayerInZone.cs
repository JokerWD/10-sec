using UnityEngine;

namespace TenSeconds
{
    public class PlayerInZone : MonoBehaviour
    {
        public bool PlayerInZoneRange { get; private set; }
        public float Range { private get; set; }
        
        
        private Transform _enemyTransform;
        private float _distanceToPlayer;
        
        private void Awake() => _enemyTransform = transform;

        public void DistanceOnPlayer(Transform player)
        {
            _distanceToPlayer = Vector2.Distance(_enemyTransform.position, player.position);
            if (_distanceToPlayer <= Range)
            {
                CheckPlayer(player);
                PlayerInZoneRange = true;
            }
            else
            {
                PlayerInZoneRange = false;
            } 
        }

        private void CheckPlayer(Transform player)
        {
            if (player.position.x > _enemyTransform.position.x && _enemyTransform.localScale.x < 0)
            {
                Flip();
            }else if (player.position.x < _enemyTransform.position.x && _enemyTransform.localScale.x > 0) 
            { 
                Flip();
            }
        }
        
        private void Flip() => _enemyTransform.localScale = new Vector2(_enemyTransform.localScale.x * -1, _enemyTransform.localScale.y);

    }
}
