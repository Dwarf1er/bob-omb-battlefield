using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private const int playerMaxHealthPoints = 8;
    
    [SerializeField] public static int playerHealthPoints = playerMaxHealthPoints;
    [SerializeField] public int playerCoins;
    [SerializeField] private Text coinText;
    [SerializeField] public GameObject[] playerHealthMeters;

    private GameObject currentMeter;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthPoints = 8;
        playerCoins = 0;
        currentMeter = playerHealthMeters[playerMaxHealthPoints];

        for(int i = 1; i < playerMaxHealthPoints; i++)
        {
            playerHealthMeters[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealthPoints <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ChangeHealthMeter()
    {
        currentMeter.SetActive(false);
        currentMeter = playerHealthMeters[playerHealthPoints];
        currentMeter.SetActive(true);
    }

    public void PlayerHit()
    {
        currentMeter = playerHealthMeters[playerHealthPoints];
        
        playerHealthPoints--;
        ChangeHealthMeter();
    }

    public void PlayerHeal()
    {
        playerCoins++;
        coinText.text = playerCoins.ToString();
        PlayerController.playerSpeed += 0.05f;
        
        if (playerHealthPoints < 8)
        {
            playerHealthPoints++;
            ChangeHealthMeter();
        }
    }
}
