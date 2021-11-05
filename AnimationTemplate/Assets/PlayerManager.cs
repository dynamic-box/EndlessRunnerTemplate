using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private PlayerDataSO playerData;

    [SerializeField] private ItemController[] itemsList;

    
    
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }
    public bool onBuyButtonPressed(int itemPrice)
    {
        if (playerData.GetCoin() >= itemPrice)
        {
            playerData.SetCoin(playerData.GetCoin() - itemPrice);
            return true;
        }
        return false;
    }

    public void onSelectButtonPressed(int itemIndex)
    {
        itemsList[playerData.currentSelectedItemIndex].unSelect();

        playerData.currentSelectedItemIndex = itemIndex;


    }
}
