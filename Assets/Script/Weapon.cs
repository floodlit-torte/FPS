using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private float range = 100f;
    [SerializeField] private ParticleSystem MuzzleFlash;
    [SerializeField] private int damage = 25;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls?.Disable(); // ? - check if object is null
    }

    private void Update()
    {
        if(playerControls.Player.Shoot.triggered)
        {
            MuzzleFlash.Play();
            RaycastHit hit;
            if(Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, range))
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if(target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
