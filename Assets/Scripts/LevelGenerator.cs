using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour {

    private GameObject[,] BoardPositions;
    public GameObject CaseModel;
    public int BoardLength = 5;
    public int BoardWidth = 5;

    void InitBoard(int longueur, int largeur)
    {
        BoardPositions = new GameObject[longueur, largeur];
        for (int i = 0; i < longueur; i++)
        {
            for (int j = 0; j < largeur; j++)
            {
                var CaseInstance = Object.Instantiate(CaseModel,new Vector3(i,0, j), new Quaternion(),this.gameObject.transform);

                if ((i+j)%2==0)
                {
                    CaseInstance.GetComponentInChildren<Renderer>().material.color = Color.black;
                }
                BoardPositions[i, j] = CaseInstance;
            }
        }
    }



    void Start () {
        InitBoard(BoardLength, BoardWidth);
	}

	void Update () {
		
	}
}
