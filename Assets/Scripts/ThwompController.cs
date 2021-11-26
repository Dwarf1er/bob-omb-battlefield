using System.Collections;
using UnityEngine;

public class ThwompController : MonoBehaviour
{
    private bool hasFallen = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        yield return new WaitForSeconds(0.4f);
        transform.Translate(Vector3.up * 1.5f);

        hasFallen = false;
    }
}
