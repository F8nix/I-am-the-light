using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        RestartPlayerPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RestartPlayerPos(){
        if(playerCharacter != null){
            playerCharacter.transform.position = transform.position;
        }
    }
}
