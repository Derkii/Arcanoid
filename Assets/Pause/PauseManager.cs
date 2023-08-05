using System.Linq;
using System.Collections.Generic;
using TNRD;
using UnityEngine;
using Derkii.FindByInterfaces;

namespace Pause
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private List<SerializableInterface<IPausable>> _pausables;

        public void Pause(bool pause)
        {
#if UNITY_EDITOR
            if (_pausables.Count == 0) Debug.LogWarning("Any pausables");
#endif
            foreach (var pausable in _pausables)
            {
                pausable.Value.SetPaused(pause);
            }
        }

        [ContextMenu("Add pausables")]
        public void Add()
        {
            var pausables = Finder.FindByInterface<IPausable>().
                Build().ComponentsAsInterface<IPausable>();

            foreach (var pausable in pausables)
            {
                if (_pausables.Select(t => t.Value).Contains(pausable)) continue;
                _pausables.Add(new SerializableInterface<IPausable> { Value = pausable });
            }
        }
    }
}