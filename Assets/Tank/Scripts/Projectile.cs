using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : Ammo
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] GameObject effect;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check if object has health component
        Health health = collision.gameObject.GetComponent<Health>();

        
        print(collision.gameObject.name);
        if (health != null)
        {
            //do damage on contact
            health.OnDamage(damage);
        }
        Instantiate(effect,transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
