using UnityEngine;
using System.Collections;

public class SettleTheScore : MonoBehaviour {

	public int score { get; private set; }
    public bool isIncrementing;
    public int timeScoreValue;

    void Update()
    {
        if (Time.time % 1 <= Time.deltaTime)
        {
            score += timeScoreValue;
        }
    }

    public void AddValue(int value)
    {
        score += value;
    }

    public int FinalScore()
    {
        isIncrementing = false;
        return score;
    }
}
