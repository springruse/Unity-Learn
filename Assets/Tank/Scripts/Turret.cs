using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 45.0f;
    [SerializeField] float fireRate = 1.0f;
    [SerializeField] Ammo ammo;
    [SerializeField] Transform muzzle;
    
    float firetimer = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firetimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        firetimer -= Time.deltaTime;

        if (firetimer < 0.0f)
        {
            firetimer += fireRate;
            Instantiate(ammo, muzzle.position, muzzle.rotation);
        }
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
