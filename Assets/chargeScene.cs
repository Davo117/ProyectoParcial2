using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chargeScene : MonoBehaviour
{
    public float startTime;
    public float endTime;
    public string scene;

    private void Update()
    {
        if(FindObjectOfType<PlayerController>() != null)
        {
            startTime = 0;
        }
        else
        {
            startTime += Time.deltaTime;
            if(startTime >= endTime)
            {
                SceneManager.LoadScene(scene);
                PointCount.Instance.playerScoreNave = 0;
                PointCount.Instance.playerHeartUI.sizeDelta = new Vector2(48, PointCount.Instance.heartSize);
            }
        }
    }
}
