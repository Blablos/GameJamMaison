using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour {

    private GameObject[,] BoardPositions;
    public GameObject[] CaseModels;
    public int BoardLength = 5;
    public int BoardWidth = 5;
    public TextAsset csv;
    void InitBoard(int longueur, int largeur)
    {
        BoardPositions = new GameObject[longueur, largeur];
        var nomMalinDeVar = CSVReader.SplitCsvGrid(csv.text);
        for (int i = 0; i < longueur; i++)
        {
            string logError = "";
            for (int j = 0; j < largeur; j++)
            {
                GameObject CaseInstance;
                logError += "|" + nomMalinDeVar[i, j] + "| ";
                switch (nomMalinDeVar[i,j])
                {
                    case "0":
                        CaseInstance = Object.Instantiate(CaseModels[0], new Vector3(i, 0, j), new Quaternion(), this.gameObject.transform);
                        break;
                    case "1":
                        CaseInstance = Object.Instantiate(CaseModels[1], new Vector3(i, 0.5f, j), new Quaternion(), this.gameObject.transform);
                        break;
                    default:
                        CaseInstance = Object.Instantiate(CaseModels[2], new Vector3(i, 0, j), new Quaternion(), this.gameObject.transform);
                        break;
                }
                BoardPositions[i, j] = CaseInstance;
            }
            Debug.Log(logError);
        }

        for (int i = 0; i < longueur; i++)
        {
            string logError = "";
            for (int j = 0; j < largeur; j++)
            {
                logError += BoardPositions[i,j].tag + " ";
            }
            Debug.Log(logError);
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
