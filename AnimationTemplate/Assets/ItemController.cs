using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    //Item haqqinda melumati dasiyan scriptable object instance
    [SerializeField] private ItemDataSO itemData;

    //Itemi almaq ve secmek ucun istifade etdiyimiz button
    [SerializeField] private Button buyOrSelectButton;

    //button uzerindeki(Buy Selected Select) yazdiracagimiz text
    [SerializeField] private Text buyOrSelectText;

    //Itemin qiymeti yazilacaq text
    [SerializeField] private Text itemPriceText;

    //Itemin seklini yerlestimek ucun Image
    [SerializeField] private Image itemIcon;

    //Ve item-in indeksi
    public int itemIndex;


    private void Start()
    {
        //Itemin sekil ve price qiymetini teyin edirik.
        itemIcon.sprite = itemData.itemImage;

        itemPriceText.text = itemData.itemPrice.ToString();

        //Eger item alinibsa
        if (itemData.isBought)
        {
            //Buttona sadece Select funksionalligi elave edirik.
            buyOrSelectButton.onClick.AddListener(onSelectButtonPressed);

            //Eger bizim item evvelceden secilibse
            if (itemData.isSelected)
            {
                //Texti deyisirik.
                buyOrSelectText.text = "Selected";
            }
            else
            {
                buyOrSelectText.text = "Select";
            }
        }
        else
        {
            //Buttona sadece buy funksionalligini elave etdik.
            buyOrSelectButton.onClick.AddListener(onBuyButtonPressed);

            buyOrSelectText.text = "Buy";
        }
    }


    private void onBuyButtonPressed()
    {
        //Eger pulumuz catarsa bu zaman true qaytarir
        if (PlayerManager.instance.onBuyButtonPressed(itemData.itemPrice))
        {
            //Itemi alir ve secir.
            itemData.isBought = true;

            itemData.isSelected = true;

            buyOrSelectText.text = "Selected";

            //Artiq buy event-na ehtiyacimiz yoxdu deye kenarlasdirdiq.
            buyOrSelectButton.onClick.RemoveAllListeners();

            //Hemin buttonu metodla secirik.
            onSelectButtonPressed();

            //Ve secim etme funksionalligini elave edirik.
            buyOrSelectButton.onClick.AddListener(onSelectButtonPressed);
        }

;    }

    private void onSelectButtonPressed()
    {
        //Biz yeni item secende evvelki item-i resetleyirik.
        PlayerManager.instance.onSelectButtonPressed(itemIndex);

        //Indiki item-i secirik.
        itemData.isSelected = true;

        //Ve buttonun text-ne selected yazisini elave edirik.
        buyOrSelectText.text = "Selected";
    }

    public void unSelect()
    {
        //Bu metodu PlayerManagerin singletonundaki onSelectButtonPressed EVVELKI ITEM ucun cagirir.
        itemData.isSelected = false;

        //Ve EVVELKI ITEM-in text-ni deyisirik.
        buyOrSelectText.text = "Select";
    }
}
