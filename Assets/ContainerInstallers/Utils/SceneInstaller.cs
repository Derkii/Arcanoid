using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ContainerInstallers.Utils
{
    [DefaultExecutionOrder(order: -5000)]
    public class SceneInstaller : MonoBehaviour
    {
        [SerializeField] private Installer[] _installers;
        [SerializeField] private GameObject[] _injectablesGameObjects;
        [SerializeField] private MonoBehaviour[] _injectableMonoBehaviours;
        private IObjectResolver _container;

        private void Awake()
        {
            var containerBuilder = new ContainerBuilder();
            if (_installers.Length == 0)
            {
                Debug.LogWarning("Installers length equals 0");
            }
            foreach (var installer in _installers)
            {
                installer.Configure(containerBuilder);
            }

            containerBuilder.Register<object>(Lifetime.Singleton).WithParameter(_container);
            _container = containerBuilder.Build();
            foreach (var injectableGameObject in _injectablesGameObjects)
            {
                _container.InjectGameObject(injectableGameObject);
            }

            foreach (var injectableMonoBehaviour in _injectableMonoBehaviours)
            {
                _container.Inject(injectableMonoBehaviour);
            }
        }

        private void OnDestroy()
        {
            _container.Dispose();
        }
    }
}