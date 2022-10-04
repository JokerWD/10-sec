using UnityEngine;

namespace TenSeconds
{
    [RequireComponent(typeof(EnemyShoot), typeof(PlayerInZone))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _data;

        private EnemyShoot _enemyShoot;
        private PlayerInZone _playerInZone;

        private void Awake()
        {
            _enemyShoot = GetComponent<EnemyShoot>();
            _playerInZone = GetComponent<PlayerInZone>();
        }

        private void Start()
        {
            _enemyShoot.FireRate = _data.FireRate;
            _playerInZone.Range = _data.Range;
        }
    }
}
