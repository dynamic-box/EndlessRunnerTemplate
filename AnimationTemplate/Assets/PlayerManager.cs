using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Singleton ucun reference
    public static PlayerManager instance;

    //playerin datalarinin(coin ve selected item indexi) idare etmek ucun reference
    [SerializeField] private PlayerDataSO playerData;

    //Butun itemController scriptlərin SIRA ilə düzülmüş arrayı
    [SerializeField] private ItemController[] itemsList;

    
    
    

    private void Awake()
    {
        instance = this;
    }

    //Bu metodla biz playerin item-a pulunun catib catmadigini yoxlayiriq.
    public bool onBuyButtonPressed(int itemPrice)
    {
        //Itemin qiymeti ile playerin coin sayini muqayise edirik.
        if (playerData.GetCoin() >= itemPrice)
        {
            //Eger playerin coin sayi uygundursa itemin qiymetini playerin coin sayindan cixiriq.
            playerData.SetCoin(playerData.GetCoin() - itemPrice);
            return true;
        }
        return false;
    }

    public void onSelectButtonPressed(int itemIndex)
    {
        //Bu indeks vasitesile yuxaridaki itemListin indekslerine gore evvelki secdiyimiz elementi deselect edirik.
        itemsList[playerData.currentSelectedItemIndex].unSelect();

        //ve hazirki secidiyimiz elementin indexini teyin edirik.
        playerData.currentSelectedItemIndex = itemIndex;


    }
}
