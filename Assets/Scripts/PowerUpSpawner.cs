using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public List<GameObject> powerPrefab;
    // Time To Double in seconds
    public int ttu = 1;
    private float maxX = 8;
    // private float maxY = 0;
    private float maxZ = 8;
    private float timePassed = 0.0f;
    // Maximum number of powerups we want to deal with
    public int maxPower = 100;
    // current number of powerups
    private int curPower = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        int powerup = 0;
        if (timePassed > ttu && curPower < maxPower) {
            if (curPower % 10 == 0) {
                powerup = 1;
            }
            timePassed = 0;
            Vector3 position = new Vector3(Random.Range(maxX * -1, maxX), 0.5f, Random.Range(maxZ * -1, maxZ));
            GameObject newObject = Instantiate(powerPrefab[powerup], position, Quaternion.identity, this.transform);
            curPower += 1;  
        }
    }
    
    public void ClaimPowerup()
    {
        curPower -= 1;
    }
}
