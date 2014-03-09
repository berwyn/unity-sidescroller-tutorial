using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    #region Designer Variables

    public Transform shotPrefab;
    public float rateOfFire = 0.25f;

    #endregion

    private float shotCooldown;

    public bool canAttack { get { return shotCooldown <= 0f; } }

    void Start()
    {
        shotCooldown = 0f;
    }

    void Update()
    {
        if (shotCooldown > 0)
        {
            shotCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        if (canAttack)
        {
            shotCooldown = rateOfFire;

            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;

            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = this.transform.right;
            }
        }
    }
}
