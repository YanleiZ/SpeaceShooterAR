using System.Collections;
using UnityEngine;

public class MyMover : MonoBehaviour {
	public GameObject spawn1;
	public GameObject spawn2;
	// Use this for initialization
	void Start () {
		spawn1 = GameObject.Find ("spawnn1");
		spawn2 = GameObject.Find ("spawnn2");
        //计算获得两个GameObject的向量
		Vector3 vv = spawn1.transform.position - spawn2.transform.position;
        //在向量方向为玩家发射的子弹添加一个力
		GetComponent<Rigidbody> ().AddForce (vv*1000);
	}
}
