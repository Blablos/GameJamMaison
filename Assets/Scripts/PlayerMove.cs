using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed=1.0f, startTime, journeyLength;
    public Vector3 startPosition, endPosition;
    private bool isMoving;
    public LevelGenerator levelGenerator;

	void Start () {
        levelGenerator = GameObject.FindGameObjectWithTag("Ground").GetComponent<LevelGenerator>();
        startPosition = transform.position;
        endPosition = transform.position;
        journeyLength = Vector3.Distance(endPosition, startPosition);
        isMoving = false;
    }

	void Update () {
        
        Vector3 PlayerPosition = transform.position;
        if (!isMoving) {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && (endPosition.x - 1 >= 0))
            {
                startTime = Time.time;
                endPosition = new Vector3(endPosition.x - 1, endPosition.y, endPosition.z);
                journeyLength = Vector3.Distance(endPosition, startPosition);
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && (endPosition.x + 1 < levelGenerator.BoardLength))
            {
                startTime = Time.time;
                endPosition = new Vector3(endPosition.x + 1, endPosition.y, endPosition.z);
                journeyLength = Vector3.Distance(endPosition, startPosition);
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && (endPosition.z + 1 < levelGenerator.BoardWidth))
            {
                startTime = Time.time;
                endPosition = new Vector3(endPosition.x, endPosition.y, endPosition.z + 1);
                journeyLength = Vector3.Distance(endPosition, startPosition);
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && (endPosition.z - 1 >= 0))
            {
                startTime = Time.time;
                endPosition = new Vector3(endPosition.x, endPosition.y, endPosition.z - 1);
                journeyLength = Vector3.Distance(endPosition, startPosition);
                isMoving = true;
            }
        }
        else
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
        }

        if(Vector3.Distance(endPosition, transform.position)<0.01)
        {
            startPosition = endPosition;
            transform.position = endPosition;
            isMoving = false;
        }
    }
}
