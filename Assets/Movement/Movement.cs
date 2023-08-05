using TNRD;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private SerializableInterface<IInput> _input;
    private IInput _inputValue => _input.Value;
    private bool _manualUpdate;
    public float Speed;

    public void SetManualUpdateMode(bool state)
    {
        _manualUpdate = state;
    }
    
    private void Update()
    {
        if (_manualUpdate) return;
        Move();
    }

    public void Move()
    {
        _rigidBody.velocity = _inputValue.Input * Speed;
    }
}