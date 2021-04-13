using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{
   

    private void Awake() {
        InstantiateCharacterPrefab();
    }

    public void InstantiateCharacterPrefab (){
        // int randomIndex = Random.Range (0, charsPrefabs.Length-1 );
        // GameObject _char = Instantiate (charsPrefabs[randomIndex], transform.position, Quaternion.identity);
        // _char.transform.parent = this.transform;
        // _char.transform.localScale = new Vector2 (charactersScale, charactersScale);
        // _char.name = this.gameObject.name + " - character prefab";
    }
}
