using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HP : MonoBehaviour
{

    [SerializeField] private List<GameObject> HpObjs;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private Text HighestScore,LatestScore;
    private const string StaticHighestScore = "Highest";
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Lolo")) return;
        Destroy(collision.gameObject);

        HpObjs[HpObjs.Count - 1].SetActive(false);
        HpObjs.Remove(HpObjs[HpObjs.Count - 1]);

        if (HpObjs.Count == 0)
        {
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
            ShowHighestScore();
        }

        //HpObjs.Length == 0 ? GameOverScreen.SetActive(true) : HpObjs[HpObjs.Length - 1];

    }

    public void ShowHighestScore()
    {
        var highestScore = PlayerPrefs.GetInt(StaticHighestScore);
        var latestScore = int.Parse(LatestScore.text);
        if (latestScore > highestScore)
        {
            highestScore = latestScore;
            PlayerPrefs.SetInt(StaticHighestScore, highestScore); 
        }
        HighestScore.text = highestScore.ToString();
    }

}
