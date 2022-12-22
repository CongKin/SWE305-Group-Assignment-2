using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class UI_Inventory : MonoBehaviour {

    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotContainerScreen;
    private Transform itemSlotTemplate;
    private Transform itemSlotTemplateScreen;
    private CharacterInventory player;
    public static bool showPanel;

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject itemSlot;

    private void Awake() {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetPlayer(CharacterInventory player) {
        this.player = player;
    }

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(showPanel)
            {
                Show();
            } else
            {
                Close();
            }
        }
    }

    public void Show()
    {
        inventoryPanel.SetActive(false);
        itemSlot.SetActive(false);
        showPanel = false;
    }

    void Close()
    {
        inventoryPanel.SetActive(true);
        itemSlot.SetActive(true);
        showPanel = true;
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e) {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() {
        foreach (Transform child in itemSlotContainer) {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 300f;
        foreach (Item item in inventory.GetItemList()) {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>(); 
            itemSlotRectTransform.gameObject.SetActive(true);
            Show();
            
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                // Use item
                inventory.UseItem(item);
            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {
                // Drop item
                Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
                inventory.RemoveItem(item);
                ItemWorld.DropItem(player.GetPosition(), duplicateItem);
                inventory.isFull--;
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1) {
                uiText.SetText(item.amount.ToString());
            } else {
                uiText.SetText("");
            }

            x++;
            if (x >= 4) {
                y++;
                x = 0;
            }
        }
    }


}
