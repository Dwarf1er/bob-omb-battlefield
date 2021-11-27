using UnityEngine;
using UnityEngine.AI;

public class BooController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform flag;

    public static bool hasRaceStarted = false;
    public static bool hasInteracted = false;

    // Start is called before the first frame update
    void Start()
    {
        hasRaceStarted = false;
        hasInteracted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            hasInteracted = true;

        if (hasRaceStarted)
            enemy.SetDestination(flag.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && hasInteracted)
            hasRaceStarted = true;
    }
}
