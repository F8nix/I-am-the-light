using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawnerManager : MonoBehaviour
{
    [SerializeField] public List<LightData> lightTypes = new List<LightData>();
    // Start is called before the first frame update

    public static LightSpawnerManager Instance { get; private set; }

    public int maxLight;
    public int currentLight;
    public int areaWidth;
    public int areaHeight;

    public Vector2 areaBottomLeftCorner;

    public GameObject playerChar;

    private Vector2 playerCharStartPos;

    //with time add maxLight/area of spawning via SO

    private void Awake() 
    {    
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    void Start()
    {
        maxLight = 50;
        currentLight = 0;

        areaWidth = 30;
        areaHeight = 30;

        playerCharStartPos = playerChar.transform.position;

        areaBottomLeftCorner = new Vector2(0, 0);

        areaBottomLeftCorner = areaBottomLeftCorner + playerCharStartPos - new Vector2(areaWidth/2, areaHeight/2);
        Debug.Log(areaBottomLeftCorner);
    }

    // Update is called once per frame
    void Update()
    {
        while(currentLight < maxLight) {
            //Debug.Log("Current: " + currentLight + " Max: " +maxLight);
            SpawnLight();
            currentLight++;
        }
    }

    public void SpawnLight() {
        Instantiate(lightTypes[0].prefab, (Vector3) RandomiseSpawnPos(), Quaternion.identity);
    }

    public Vector2 RandomiseSpawnPos() {
        float xPos = Random.Range(areaBottomLeftCorner.x, areaBottomLeftCorner.x + areaHeight + 1.0f);
        float yPos = Random.Range(areaBottomLeftCorner.y, areaBottomLeftCorner.y + areaWidth+ 1.0f);
        
        return new Vector2(xPos, yPos);
    }
}
