using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public int walkSpeed;
    public int sprintSpeed;
    public int sprintCount;
    public int jumpPower;
    public int jumpCount;
    public int currentWalkSpeed;

    private Vector3 movementVecter;
    private Rigidbody cubeRigidbody;

    private void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        walkSpeed = 16;
        sprintSpeed = 23;
        jumpPower = 50;
        jumpCount = 0;
        UpdateCurrentWalkSpeed();

        cubeRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movementVecter = transform.forward * moveVertical + transform.right * moveHorizontal;
        transform.position += movementVecter * currentWalkSpeed * Time.deltaTime;
    }

    public void UpdateCurrentWalkSpeed()
    {
        if (sprintCount == 0)
        {
            currentWalkSpeed = walkSpeed;
        }
        else
        {
            currentWalkSpeed = sprintSpeed;
        }
    }

    public void UpdateHealthState()
    {
        if (health <= 0)
        {

        }
        else if (health > maxHealth)
        {
            health = maxHealth;
        }
        else
        {

        }
    }

    public void TryJump()
    {
        if (jumpCount < 1)
        {
            cubeRigidbody.AddForce(Vector3.up, ForceMode.Impulse);
            Physics.gravity = new Vector3(0, -jumpPower, 0);
            jumpCount++;
        }
    }

    public void TrySprint()
    {
        if (sprintCount < 1)
        {

            sprintCount++;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprintCount = 1;
        }
        else
        {
            sprintCount = 0;
        }

        UpdateCurrentWalkSpeed();
        UpdateHealthState();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            jumpCount = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                TryJump();
            }
        }
    }
}
