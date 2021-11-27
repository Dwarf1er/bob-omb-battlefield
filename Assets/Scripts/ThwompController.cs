using System.Collections;
using UnityEngine;

public class ThwompController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    private ParticleSystem.EmissionModule emission;
    private bool hasFallen = false;

    // Start is called before the first frame update
    void Start()
    {
        emission = particle.emission;
        emission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasFallen)
        {
            hasFallen = true;
            StartCoroutine(Crush());
        }
    }

    private IEnumerator Crush()
    {
        yield return new WaitForSeconds(0.4f);        
        transform.Translate(Vector3.down * transform.localScale.y);
        emission.enabled = true;        
        yield return new WaitForSeconds(0.8f);
        emission.enabled = false;
        transform.Translate(Vector3.up * transform.localScale.y);

        hasFallen = false;
    }
}
