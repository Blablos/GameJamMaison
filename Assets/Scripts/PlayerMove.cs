using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public GameObject Player;

	void Start () {
		
	}

	void Update () {
        Vector3 PlayerPosition = Player.transform.position;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Player.transform.position = new Vector3(PlayerPosition.x - 1, PlayerPosition.y, PlayerPosition.z);
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Player.transform.position = new Vector3(PlayerPosition.x + 1, PlayerPosition.y, PlayerPosition.z);
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Player.transform.position = new Vector3(PlayerPosition.x, PlayerPosition.y, PlayerPosition.z + 1);
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Player.transform.position = new Vector3(PlayerPosition.x, PlayerPosition.y, PlayerPosition.z - 1);
        }
    }
}
