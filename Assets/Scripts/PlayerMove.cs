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

        if(!isMoving)
        {
            Vector3 positionPreview = startPosition;

            if (Input.GetKeyDown(KeyCode.LeftArrow) && (endPosition.x - 1 >= 0))
            {
                positionPreview = new Vector3(startPosition.x - 1, startPosition.y, startPosition.z);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && (endPosition.x + 1 < levelGenerator.BoardLength))
            {
                positionPreview = new Vector3(startPosition.x + 1, startPosition.y, startPosition.z);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && (endPosition.z - 1 >= 0))
            {
                positionPreview = new Vector3(startPosition.x, startPosition.y, startPosition.z - 1);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && (endPosition.z + 1 < levelGenerator.BoardWidth))
            {
                positionPreview = new Vector3(startPosition.x, startPosition.y, startPosition.z + 1);
            }

            switch(levelGenerator.GetCaseTypeTag((int) positionPreview.x,(int) positionPreview.z))
            {
                case "Wall":
                    positionPreview = startPosition;
                    break;
                case "Void":
                    positionPreview = startPosition;
                    break;
                default:
                    break;
            }

            if(positionPreview != startPosition)
            {
                startTime = Time.time;
                endPosition = positionPreview;
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
