using UnityEngine;
using VContainer;

namespace ContainerInstallers.Utils
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Configure(IContainerBuilder builder);
    }
}
