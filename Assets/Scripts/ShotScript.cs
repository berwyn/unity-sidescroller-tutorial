using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	#region Designer Variables
	public int damage = 1;
	public bool isEnemyShot = false;
	#endregion

	void Start () {
		Destroy(gameObject, 20);
	}
}
