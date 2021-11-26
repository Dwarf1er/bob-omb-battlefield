using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private GameObject pickupSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // PlayerHeal() adds one coin to the picked up coins
            other.GetComponent<PlayerStats>().PlayerHeal();

            Instantiate(pickupSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
