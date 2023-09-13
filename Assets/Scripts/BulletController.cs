using UnityEngine;
using System;
using System.Collections;

public class BulletController : MonoBehaviour
{
	#region Constants
	private float SPEED = 10f;
	#endregion Constants

	#region Fields
	private Action onKillEnemy;
	#endregion Fields

	#region Properties
	public Action OnKillEnemy { set { this.onKillEnemy = value; } }
	#endregion Properties
	
	#region Methods
	public void Update ()
	{
		this.transform.position = new Vector3
		(
			this.transform.position.x,
			this.transform.position.y + SPEED * Time.deltaTime,
			this.transform.position.z
		);

		if (this.transform.position.y > 6)
		{
			GameObject.Destroy(this.gameObject);
		}
	}

	public void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.GetComponent<EnemyController>() != null)
		{
			onKillEnemy();

			GameObject.Destroy(this.gameObject);
			GameObject.Destroy(collider.gameObject);
		}
	}
	#endregion Methods
}
