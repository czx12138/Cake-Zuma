using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject balls;
    public KeyCode key;
    private float shootUsageTime;
    [SerializeField] private float shootCooldown;

    private void Update()
    {
        shootUsageTime -= Time.deltaTime;
        if (Input.GetKeyDown(key) && shootUsageTime < 0)
        {
            shootUsageTime = shootCooldown;
            Instantiate(balls,transform.position, transform.rotation);
        }
    }
}
