using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCount : MonoBehaviour
{
    public int playerScoreNave;
    public static PointCount Instance;
    // Start is called before the first frame update

    public RectTransform playerHeartUI;
    public SpriteRenderer playerRenderer;
    public float heartSize = 16f;
    public TextMeshProUGUI textEnemyCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }

        playerRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        textEnemyCount.text = playerScoreNave.ToString();
    }

    public void AddPoints(int shipPoints)
    {
        playerScoreNave += shipPoints;
    }

}
