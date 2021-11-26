using UnityEngine;

public class ThwompCrushDetector : MonoBehaviour
{    
    private bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasHit)
        {
            hasHit = true;
            other.GetComponent<PlayerStats>().PlayerHit();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hasHit = false;
    }
}
