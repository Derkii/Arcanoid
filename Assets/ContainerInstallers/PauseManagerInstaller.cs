using ContainerInstallers.Utils;
using Pause;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ContainerInstallers
{
    public class PauseManagerInstaller : Installer
    {
        [SerializeField] private PauseManager _manager;

        public override void Configure(IContainerBuilder builder)
        { 
            builder.RegisterComponent(_manager);
        }
    }
} 