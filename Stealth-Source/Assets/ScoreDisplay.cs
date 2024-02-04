using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreUI;

    public int score = 0;

     void Start()
    {
        IEnumerator c = ScoreAnim(50);
        StartCoroutine(c);
    }

     IEnumerator ScoreAnim(int to)
    {
        Debug.Log("go to "+to);
        int diff = to - score;

        for(int j = 0; j < diff; j++)
        {
            Debug.Log("loop");
            score++;
            scoreUI.text = score.ToString();
            yield return new WaitForSeconds(.1f);
        }
    }
}
