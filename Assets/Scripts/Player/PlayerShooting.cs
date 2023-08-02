using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField] Camera cam;
    [SerializeField] LayerMask layerMask;
    public PlayerWeapon weapon;
    

	void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
		}
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.effectiveRange, layerMask))
        {
            var targetHealth = hit.collider.gameObject.GetComponent<Health>();
            targetHealth.TakeDamage(10);
            Debug.Log("We hit " + hit.collider.name);
        }
    }
}
