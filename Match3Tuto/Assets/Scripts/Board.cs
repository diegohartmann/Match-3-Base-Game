using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //-----------------------------------------------------
    [Header("Board")]
    public int width = 7, height = 10;
    // [SerializeField] private Vector2 Offset = new Vector2 (0,0);
    [Header("Tiles")]
    [SerializeField] private GameObject tilePrefab = null;
    [SerializeField] private float tileScale = 1f;
                     private BackgroundTile [,] allTiles;
    //-----------------------------------------------------
    [Header("Personagens")]
    [SerializeField] private GameObject[] dotPrefabs = null;
                     public GameObject[,] allDots = null;
    [SerializeField] private float charactersScale = 0.4f;
    //------------------------------------------------------

    private void Awake()
    {
        allTiles = new BackgroundTile [ width, height ];
        allDots = new GameObject [ width, height ];
        CreateTiles();
    }
    
    private void CreateTiles(){
        for(int i = 0; i < width; i ++){ //linha
            for(int j = 0; j < height; j ++){ //coluna
                // Vector2 pos = new Vector2(i,j) - Offset;
                Vector2 pos = new Vector2(i,j);
                string name = "( " + i + ", " + j + " )";

                InstantiateInScene(tilePrefab, pos, tileScale, (name + " - tile"));
                //--------------
                GameObject character = dotPrefabs[ (Random.Range (0, dotPrefabs.Length)) ];
                allDots[i,j] = InstantiateInScene(character, pos, charactersScale, (name + " - personagem"));
            }
        }
    }

    public GameObject InstantiateInScene(GameObject _object, Vector2 _position, float _scale, string _name){
        GameObject element = Instantiate (_object, _position, Quaternion.identity) as GameObject;
        element.transform.parent = this.transform;
        element.transform.localScale = new Vector2 (_scale, _scale);
        element.name = _name;
        return element;
    }
}
