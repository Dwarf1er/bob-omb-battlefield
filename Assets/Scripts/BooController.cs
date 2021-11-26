using UnityEngine;
using UnityEngine.AI;

public class BooController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform flag;

    public static bool hasRaceStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        hasRaceStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasRaceStarted)
            enemy.SetDestination(flag.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            hasRaceStarted = true;
        }
    }
}
