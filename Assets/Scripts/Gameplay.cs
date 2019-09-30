using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] int miningSpeed = 3;
    [SerializeField] int bronzeSupply = 3;
    [SerializeField] int silverSupply = 2;
    [SerializeField] int playerBronze;
    [SerializeField] int playerSilver;
    public GameObject Bronze;
    public GameObject Silver;
    public GameObject Gold;
    int bronzeSpawnSpot = 0;
    int silverSpawnSpot = 0;
    int goldSpawnSpot = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerBronze = 0;
        playerSilver = 0;
        InvokeRepeating("Mining", miningSpeed, miningSpeed);
    }

    void Mining()
    {
        if (playerBronze < 4)
            {
            playerBronze ++;
            Instantiate(Bronze, new Vector3(bronzeSpawnSpot, 0, 0), Quaternion.identity);
            bronzeSpawnSpot += 2;
        }
        else if (playerBronze >= 4)
            {
            playerSilver ++;
            Instantiate(Silver, new Vector3(silverSpawnSpot, 2, 0), Quaternion.identity);
            silverSpawnSpot += 2;
        }
        if (playerBronze > 2 && playerSilver > 2)
        {
            Destroy(GameObject.Find("Bronze" + "(Clone)"));
            Destroy(GameObject.Find("Bronze" + "(Clone)"));
            Destroy(GameObject.Find("Silver" + "(Clone)"));
            Destroy(GameObject.Find("Silver" + "(Clone)"));
            playerBronze -= 2;
            playerSilver -= 2;
            Instantiate(Gold, new Vector3(goldSpawnSpot, 4, 0), Quaternion.identity);
            goldSpawnSpot += 2;
        }
        // The gold would never spawn if the code was exactly as the document described in Part 4.
        // Therefore, I decided to interperet it as a currency conversion system. 1 gold = 2 bronze and 2 silver.
        DisplayPlayerSupplies();
    }

    void DisplayPlayerSupplies()
    {
        print("Player bronze: ");
        print(playerBronze);
        print("Player silver: ");
        print(playerSilver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
