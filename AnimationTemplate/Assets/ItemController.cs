using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] private ItemDataSO itemData;

    [SerializeField] private Button buyOrSelectButton;

    [SerializeField] private Text buyOrSelectText;

    public int itemIndex;


    private void Start()
    {
        if (itemData.isBought)
        {
            buyOrSelectButton.onClick.AddListener(onSelectButtonPressed);

            if (itemData.isSelected)
            {
                buyOrSelectText.text = "Selected";
            }
            else
            {
                buyOrSelectText.text = "Select";
            }
        }
        else
        {
            buyOrSelectButton.onClick.AddListener(onBuyButtonPressed);

            buyOrSelectText.text = "Buy";
        }
    }


    private void onBuyButtonPressed()
    {
        if (PlayerManager.instance.onBuyButtonPressed(itemData.itemPrice))
        {
            itemData.isBought = true;

            itemData.isSelected = true;

            buyOrSelectText.text = "Selected";
        }

        buyOrSelectButton.onClick.RemoveListener(onBuyButtonPressed);
;    }

    private void onSelectButtonPressed()
    {
        PlayerManager.instance.onSelectButtonPressed(itemIndex);

        itemData.isSelected = true;
    }

    public void unSelect()
    {
        itemData.isSelected = false;

        buyOrSelectText.text = "Select";
    }
}
