using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;

    public PlayerDataSO playerData;

    private void Awake()
    {
        instance = this;
    }


}
