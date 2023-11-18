using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot2 : MonoBehaviour
{
    public GameObject balls;
    private float shootUsageTime;
    [SerializeField] private float shootCooldown;

    private void Update()
    {
        shootUsageTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow) && shootUsageTime < 0)
        {
            shootUsageTime = shootCooldown;
            Instantiate(balls, transform.position, transform.rotation);
        }
    }
}
