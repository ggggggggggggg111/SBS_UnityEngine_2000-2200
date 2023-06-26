using System;
using UnityEngine;


public abstract class Character : MonoBehaviour,IHp
{
    protected Movement movement;
    protected StateMachine stateMachine;

    public float hp
    {
        get => _hp;
        set
        {
            if (_hp == value)
                return;
            float prev = _hp;
            _hp = value;

            OnHpChanged?.Invoke(value);
            if(prev > value)
            {
                OnHpDecreased?.Invoke(prev - value);
                if (value <= _hpMin)
                {
                    onHpMin?.Invoke();
                }
            }
            else
            {
                OnHpDecreased?.Invoke(value - prev);
                if (value >=_hpMax)
                {
                    onHpMax?.Invoke();
                }
            }
        }
    }
    public float hpMin => _hpMin;
    public float hpMax => _hpMax;

    
     protected float _hp;
     protected float _hpMin;
    [SerializeField] protected float _hpMax;

    public event Action<float> OnHpChanged;
    public event Action<float> OnHpDecreased;
    public event Action<float> OnHpIncreased;
    public event Action onHpMin;
    public event Action onHpMax;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        stateMachine = GetComponent<StateMachine>();

        movement.onHorizontalChanged += (value) =>
        {
            stateMachine.ChangeState(value == 0.0f ? StateType.Idle : StateType.Move);
        };
    }

    protected virtual void Start()
    {
        hp = hpMax;
    }
}