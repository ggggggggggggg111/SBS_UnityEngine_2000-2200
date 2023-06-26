using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHp 
{
    float hp { get; set; }
    float hpMin { get; }
    float hpMax { get; }
    event Action<float> OnHpChanged;
    event Action<float> OnHpDecreased;
    event Action<float> OnHpIncreased;
    event Action onHpMin;
    event Action onHpMax;
 }
