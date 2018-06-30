using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        Vector3 PlayerPosition = transform.position;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position = new Vector3(PlayerPosition.x - 1, PlayerPosition.y, PlayerPosition.z);
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position = new Vector3(PlayerPosition.x + 1, PlayerPosition.y, PlayerPosition.z);
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.position = new Vector3(PlayerPosition.x, PlayerPosition.y, PlayerPosition.z + 1);
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.position = new Vector3(PlayerPosition.x, PlayerPosition.y, PlayerPosition.z - 1);
        }
    }
}
