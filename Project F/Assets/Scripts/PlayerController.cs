using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
	TimeTravel traveling;
    AudioSource audiosrc;

    public Animator animator;
    public Vector2 playerVelocity;
    public BulletController bulletController;
    public Vector3 mousePosition;
    private Plane plane;

    float horizontal;
    float vertical;
    float isRunning;
    bool isMoving;
	public bool hasWeapon;

    public int maxAmmo;
    public int currentAmmo;
    public float attackSpeed;
    public float attackCooldown;

    public float walkSpeed = 2.5f;
    public float runSpeed = 5.0f;
    public AudioClip[] clips;

    void Start()
    {
		hasWeapon = false;
        body = GetComponent<Rigidbody2D>();
		traveling = GetComponent<TimeTravel>();
        plane = new Plane(Vector3.back, 0);
        audiosrc = GetComponent<AudioSource>();
        audiosrc.playOnAwake = false;
        audiosrc.loop = false;
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
                    if (!audiosrc.isPlaying)
                    {
                        audiosrc.clip = clips[1];
                        audiosrc.volume = Random.Range(0.3f, 0.5f);
                        audiosrc.Play();
                    }
                }
				else 
				{
					playerVelocity *= walkSpeed;
                    if (!audiosrc.isPlaying)
                    {
                        audiosrc.clip = clips[0];
                        audiosrc.volume = Random.Range(0.3f, 0.5f);
                        audiosrc.Play();
                    }
                }
			}
			else
			{
				playerVelocity = Vector2.zero;
                if (!audiosrc.isPlaying)
                {
                    audiosrc.Stop();
                }
            }
 
            body.velocity = playerVelocity;
			//Debug.Log(body.velocity);
			attackCooldown += Time.deltaTime;

			if (Input.GetButtonDown("Fire1") && hasWeapon)
			{
				if (attackSpeed <= attackCooldown)
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
					attackCooldown = 0;
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
