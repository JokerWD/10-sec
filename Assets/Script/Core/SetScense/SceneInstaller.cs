using Dythervin.AutoAttach;
using TenEnemy;
using TenSeconds;
using UnityEngine;
using Zenject;

namespace TenCore
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField, Attach(Attach.Scene)] private Timer _timer;
        
        [Header("PLAYER")]
        [SerializeField, Attach(Attach.Scene)] private PlayerController _playerController;
        [SerializeField, Attach(Attach.Scene)] private MeleeWeapon _meleeWeapon;
        [SerializeField, Attach(Attach.Scene)] private Player _player;
        [SerializeField, Attach(Attach.Scene)] private HealthPlayer _healthPlayer;
        
        [Header("SPAWNER")]
        [SerializeField, Attach(Attach.Scene)] private ArrowSpawn _arrowSpawn;
        [SerializeField, Attach(Attach.Scene)] private BulletSpawn _bulletSpawn;


        [Header("CORE")] 
        [SerializeField, Attach(Attach.Scene)] private CheckEnemy _checkEnemy;
        [SerializeField, Attach(Attach.Scene)] private CameraShake _cameraShake;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle();
            Container.Bind<MeleeWeapon>().FromInstance(_meleeWeapon).AsSingle();
            Container.Bind<Player>().FromInstance(_player).AsSingle();
            Container.Bind<Timer>().FromInstance(_timer).AsSingle();
            Container.Bind<HealthPlayer>().FromInstance(_healthPlayer).AsSingle();
            Container.Bind<ArrowSpawn>().FromInstance(_arrowSpawn).AsSingle();
            Container.Bind<BulletSpawn>().FromInstance(_bulletSpawn).AsSingle();
            Container.Bind<CheckEnemy>().FromInstance(_checkEnemy).AsSingle();
            Container.Bind<CameraShake>().FromInstance(_cameraShake).AsSingle();
        }
    }
}
