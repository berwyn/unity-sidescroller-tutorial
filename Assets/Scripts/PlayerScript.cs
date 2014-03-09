using UnityEngine;
using System.Collections;

/// <summary>
/// This script handles player behaviour
/// </summary>
public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    private Vector2 movement;

    void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        movement = new Vector2(
                speed.x * inputX,
                speed.y * inputY
        );

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            var weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        var enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            var enemyHealth = enemy.gameObject.GetComponent<HealthScript>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

            damagePlayer = true;
        }

        if (damagePlayer)
        {
            var playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) playerHealth.Damage(1);
        }
    }
}
