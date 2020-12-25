using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector2 velocity;
    public Rigidbody2D body;
    public float bulletSpeed;
    public float lifeTime = 5f;
	
	public float damage = 2f;
	
    public LayerMask canAttackLayers;
    public LayerMask wallLayer;

	
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + velocity * bulletSpeed * Time.fixedDeltaTime);
    }

    public void SetVelocity(Vector2 q)
    {
        velocity = q;
    }
	
	void OnCollisionEnter2D(Collision2D hit)
    {
        if (canAttackLayers == (canAttackLayers | (1 << hit.gameObject.layer)))
        {
			if (hit.gameObject.GetComponent<BaseEnemy>() != null)
			{
				hit.gameObject.GetComponent<BaseEnemy>().damaged(damage);
				//hit.gameObject.GetComponent<EntityBase>().Damaged(damage* player.GetDamageModifier());
				//hit.gameObject.GetComponent<EntityBase>().ApplyKnockback(0.1f*player.GetRangeWeaponHoldModifier(),player.knockbackVector2D(hit.gameObject.transform.position,player.gameObject.transform.position), player.GetRangeWeaponKnockbackModifier());
				Destroy(this.gameObject);
			}
        }
        else if (hit.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            /*Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit rayHit;

            if (Physics.Raycast(ray, out rayHit, Time.deltaTime * speed + 0.1f, wallLayer))
            {
                Vector3 reflectDir = Vector3.Reflect(ray.direction, rayHit.normal);
                float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x)* Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, rot, 0);
                speed *= 1.2f;
                Ricochete = true;

            }*/
			Destroy(this.gameObject);
        }
    }
}
