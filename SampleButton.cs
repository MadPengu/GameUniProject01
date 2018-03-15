using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SampleButton : MonoBehaviour {
    public Button buttonComponent;
    public Text nameLabel;
    public Image iconImage;
    public Text priceText;

    private Item item;

    private ShopScrollList ScrollList;
    // Use this for initialization
    void Start ()
    {
        buttonComponent.onClick.AddListener(HandleClick);
	}
	
	public void Setup(Item CurrentItem, ShopScrollList CurrentScrollList)
    {
        item = CurrentItem;
        nameLabel.text = item.ItemName;
        priceText.text = item.price.ToString();
        iconImage.sprite = item.Icon;

        ScrollList = CurrentScrollList;

    }

    public void HandleClick()
    {
        ScrollList.TransferItem(item); 
    }
}
