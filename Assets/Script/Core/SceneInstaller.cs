using Dythervin.AutoAttach;
using TarodevController;
using UnityEngine;
using Zenject;

namespace TenCore
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField, Attach(Attach.Scene)] private PlayerController _playerController;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle();
        }
    }
}
