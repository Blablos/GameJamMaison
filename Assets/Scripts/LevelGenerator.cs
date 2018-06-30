using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour {

    private GameObject[,] BoardPositions;
    public GameObject[] CaseModels;
    public int BoardLength = 5;
    public int BoardWidth = 5;

    void InitBoard(int longueur, int largeur)
    {
        BoardPositions = new GameObject[longueur, largeur];
        for (int i = 0; i < longueur; i++)
        {
            for (int j = 0; j < largeur; j++)
            {
                var CaseInstance = Object.Instantiate(CaseModels[0],new Vector3(i,0, j), new Quaternion(),this.gameObject.transform);

                if ((i+j)==4)
                {
                    //CaseInstance.GetComponentInChildren<Renderer>().material.color = Color.black;
                    CaseInstance = Object.Instantiate(CaseModels[1], new Vector3(i, 0.5f, j), new Quaternion(), this.gameObject.transform);
                }
                BoardPositions[i, j] = CaseInstance;
            }
        }
    }


    public string GetCaseTypeTag(int posX, int posY)
    {
        return BoardPositions[posX, posY].tag;
    }



    void Start () {
        InitBoard(BoardLength, BoardWidth);
	}

	void Update () {
		
	}
}
