using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    [SerializeField] private GameObject star;
    
    private bool hasBeenCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        hasBeenCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasBeenCollected && BooController.hasRaceStarted)
        {
            hasBeenCollected = true;
            Instantiate(star, transform.position + new Vector3(0f, 3f, 3f), Quaternion.identity);
        }

        if (other.gameObject.tag == "Boo" && !hasBeenCollected && BooController.hasRaceStarted)
        {
            hasBeenCollected = true;
            
            for(int i = 0; i < 8; i++)
            {
                Debug.Log("HP: " + PlayerStats.playerHealthPoints);
                GameObject.Find("Mario").GetComponent<PlayerStats>().PlayerHit();
            }                
        }
    }
}
