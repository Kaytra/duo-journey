using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager instance;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int CollectableAmount;
    public int score;
    private GameObject player;
    private int playerHealth;
    private int collectedScore = 0;
    
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       if(instance == null)
       {
            instance = this;
       }
    }

    void Update()
    {
        playerHealth = player.GetComponent<PlayerHealth>().health;

        if (playerHealth == 0)
        {
            score = collectedScore;
            Invoke("updateScore", 2.2f);
        }
    }

    public void ChangeScore(int collectableValue)
    {
        score += collectableValue;
        text.text = "Collectables:" + score.ToString();
    }

    private void updateScore()
    {
        text.text = "Collectables: " + score.ToString();
    }

    public int getScore()
    {
        return score;
    }

    public void increaseScore(int value)
    {
        score += value;
        updateScore();
    }

    public void decreaseScore(int value)
    {
        score -= value;
        if (score < 0)
            score = 0;
        updateScore();
    }

    public void saveCollected()
    {
        collectedScore = score;
        GetComponent<ItemReactivateBulk>().SaveCollectables();
    }

    public void saveDoor()
    {
        GetComponent<ItemReactivateBulk>().SaveDoors();
    }
}
