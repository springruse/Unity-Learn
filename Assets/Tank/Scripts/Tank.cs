using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 90.0f; // rotation in degrees per second
    
    [SerializeField] GameObject ammo;
    [SerializeField] GameObject muzzle;

    [SerializeField] Slider healthBar;

    InputAction moveAction;
    InputAction fireAction;

    Health health;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Attack");

        fireAction.started += ctx => OnAttack();
        health = GetComponent<Health>();
    }

    void Update()
    {
        // direction (forward/backward movement)
        float direction = moveAction.ReadValue<Vector2>().y;

        // translate (move) the tank in the forward direction
        // moves the tank in the relative direction (direction tank is facing)
        transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);

        // rotation (left/right)
        float rotation = moveAction.ReadValue<Vector2>().x;

        // rotate the tank, around the up axis (y-axis)
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);

        healthBar.value = health.CurrentHealthPercentage;

    }
    void OnAttack()
    {
        Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
    }
}
