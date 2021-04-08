using UnityEngine.Events;

namespace CleverCrow.Fluid.Gauges {
    public interface IGaugeChangeEvent {
        void AddListener (UnityAction<int, int> call);
        void RemoveListener (UnityAction<int, int> call);
    }
}
