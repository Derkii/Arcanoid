using ContainerInstallers.Utils;
using Menus.PauseMenu;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ContainerInstallers
{
    public class PauseMenuInstaller : Installer
    {
        [SerializeField] private PauseMenuData _pauseMenu;

        public override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_pauseMenu);
        }
    }
}
