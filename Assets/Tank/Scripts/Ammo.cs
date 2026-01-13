using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    [SerializeField, Range(1, 100)] protected float damage = 50;
}
