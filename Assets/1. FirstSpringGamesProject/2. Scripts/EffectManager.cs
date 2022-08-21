using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] GameObject ExplosionEffect;

    public void CreateEffect (Vector3 position)
    {
        Instantiate(ExplosionEffect, position, Quaternion.identity);
    }
}
