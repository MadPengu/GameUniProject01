using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Item
{
    public string ItemName;
    public Sprite Icon;
    public float price = 1f;
}

public class ShopScrollList : MonoBehaviour {
    public List<Item> ItemList;
    public Transform ContentPanel;
    public ShopScrollList OtherShop;
    public Text MyGoldDisplay;
    public SimpleObjectPool ButtonObjectPool;
    public float Gold = 20;

	// Use this for initialization
	void Start () {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        MyGoldDisplay.text = "Gold: " + Gold.ToString();
        RemoveButtons();
        AddButtons();
        
    }

    private void AddButtons()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            Item item = ItemList[i];
            GameObject newButton = ButtonObjectPool.GetObject();
            newButton.transform.SetParent(ContentPanel);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item, this);
        }
    }

    private void RemoveButtons()
    {
        while (ContentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            ButtonObjectPool.ReturnObject(toRemove);
        }
    }
    

    public void TransferItem(Item Item)
    {
        if (OtherShop.Gold >= Item.price)
        {
            Gold += Item.price;
            OtherShop.Gold -= Item.price;
            AddItem(Item, OtherShop);
            RemoveItem(Item, this);

            RefreshDisplay();
            OtherShop.RefreshDisplay();
        }
    }



    private void AddItem(Item ItemToAdd, ShopScrollList ShopList)
    {
        ShopList.ItemList.Add(ItemToAdd);

    }

    

    private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
    {
        for (int i = shopList.ItemList.Count - 1; i >= 0; i--)
        {
            if (shopList.ItemList[i] == itemToRemove)
            {
                shopList.ItemList.RemoveAt(i);
            }
        }
    }
}
