using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EblominoGrid
{

}
public class EblominoController : MonoBehaviour {

    private GameObject player;
    private Transform player_transform;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //player_transform = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce((player.transform.position - transform.position).normalized);
	}
}
