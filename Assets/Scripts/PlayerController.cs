using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	
	void Update ()
	{
		//点击触摸屏则发射子弹
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			//播放声音
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
		//为了方便调试，接收键盘输入左右移动
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		//速度
		GetComponent<Rigidbody>().velocity = movement * speed;
		//位置
		GetComponent<Rigidbody>().position = new Vector3
		(
			//MathF.Clamp函数返回0~1之间的数值，如果value小于0，返回0。如果value大于1,返回1，否则返回value 。
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);		
	}
}
