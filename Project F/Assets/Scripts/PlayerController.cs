using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
	TimeTravel traveling;
	
    public Animator animator;
    public Vector2 playerVelocity;
    public BulletController bulletController;
    public Vector3 mousePosition;
    private Plane plane;

    float horizontal;
    float vertical;
    float isRunning;

    public int maxAmmo;
    public int currentAmmo;
    public float attackSpeed;
    public float attackCouldown;

    public float walkSpeed = 2.5f;
    public float runSpeed = 5.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
		traveling = GetComponent<TimeTravel>();
        plane = new Plane(Vector3.back, 0);
    }

    void Update()
    {
		if (!HealthSystem.dead)
		{
			animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
			animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
			animator.SetFloat("isRunning", Input.GetAxisRaw("Run"));
			
			horizontal = Input.GetAxisRaw("Horizontal");
			vertical = Input.GetAxisRaw("Vertical");
			isRunning = Input.GetAxisRaw("Run");

			if (horizontal != 0 || vertical != 0)
			{
				playerVelocity = new Vector2(horizontal, vertical);
				playerVelocity = playerVelocity.normalized;
				if (isRunning > 0)
				{
					playerVelocity *= runSpeed;
				}
				else 
				{
					playerVelocity *= walkSpeed;
				}
			}
			else
			{
				playerVelocity = Vector2.zero;
			}

			body.velocity = playerVelocity;
			//Debug.Log(body.velocity);
			attackCouldown += Time.deltaTime;

			if (Input.GetButtonDown("Fire1"))
			{
				if (attackSpeed <= attackCouldown)
				{
					float distance;
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					if (plane.Raycast(ray, out distance))
					{
						mousePosition = ray.GetPoint(distance);
					}
					Debug.Log(mousePosition);
					GameObject pew = Instantiate(bulletController.gameObject, this.transform.position, this.transform.rotation);
					pew.GetComponent<BulletController>().SetVelocity(new Vector2(mousePosition.x - this.transform.position.x, mousePosition.y - this.transform.position.y).normalized);
					attackCouldown = 0;
				}
			}
			
			if (Input.GetButtonDown("Fire2"))
			{
				traveling.travel();
			}
		}
    }

    void FixedUpdate()
    {
        
    }
}
