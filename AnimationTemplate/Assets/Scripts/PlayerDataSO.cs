using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPlayerData",menuName ="ScriptableObjects/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField] private int score;

    [SerializeField] private int musicVolume;

    [SerializeField] private int soundVolume;

    [SerializeField] private bool isMusicOn;

    [SerializeField] private bool isSoundOn;


}
