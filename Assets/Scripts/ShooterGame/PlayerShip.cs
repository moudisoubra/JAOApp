using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D rb;
    public float moveSpeed = 0.1f;
    public float shootTimer;
    public float shootRate;
    public bool start;
    public GameObject ammo;
    public void Start()
    {
        shootTimer = shootRate;
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        shootTimer += Time.deltaTime;
        if (Input.GetMouseButton(0) && start)
        {
            MoveShipMouse();
            ShootAmmo();
        }

        if (Input.touchCount > 0)
        {
            MoveShipTouch();
        }

    }

    public void StartGame()
    {
        start = true;
    }
    public void MoveShipMouse()
    {
        transform.position = Vector2.Lerp(transform.position, Input.mousePosition, moveSpeed);
    }
    public void MoveShipTouch()
    {
        Touch touch = Input.GetTouch(0);
        transform.position = Vector2.Lerp(transform.position, touch.position, moveSpeed);
    }
    public void ShootAmmo()
    {
        if (shootTimer > shootRate)
        {
            Instantiate(ammo, transform.position, Quaternion.identity);
            shootTimer = 0;
        }
    }
}
