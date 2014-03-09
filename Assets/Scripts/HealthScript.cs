using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
    #region Designer Variables

    public int hp = 1;
    public bool isEnemy = true;

    #endregion

    public void Damage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null && shot.isEnemyShot != isEnemy)
        {
            Damage(shot.damage);
            Destroy(shot.gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
