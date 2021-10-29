using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPlayerData",menuName ="ScriptableObjects/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField] private int score;

    public float musicVolume;

     public float soundVolume;

    public bool isMusicOn;

    public bool isSoundOn;

    [SerializeField] private int coin;

    public void SetScore(int newScore)
    {
        score = newScore;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetCoin(int coinCount)
    {
        coin=coinCount;
    }

    public int GetCoin()
    {
        return coin;
    }



}
