using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableFood : MonoBehaviour
{
    public float price;
    public Text priceDisplay;
    public GameObject priceTextObject;
    public static SelectableFood currentlySelected = null;
    private bool isSelected = false;
    public static int selectedItemCount = 0;

    // Reference to the receipt canvas' Text component.
    public static Text receiptText;

    // Dictionary to keep track of selected items and their prices.
    public static Dictionary<string, float> selectedItems = new Dictionary<string, float>();

    // List to track all instances of SelectableFood.
    public static List<SelectableFood> allItems = new List<SelectableFood>();

    private void Awake()
    {
        // Reset all static fields upon the creation of the first instance
        ResetStaticFields();
    }

    private void Start()
    {
        priceTextObject.SetActive(false); // Hide the price text

        // Initialize the receipt text if it hasn't been done.
        if (receiptText == null)
        {
            // Find the GameObject named "ReceiptCanvas" and retrieve its Text component.
            GameObject receiptCanvas = GameObject.Find("ReceiptCanvas");
            receiptText = receiptCanvas.GetComponentInChildren<Text>();
        }

        allItems.Add(this); // Register this instance to the allItems list
    }

    private void OnMouseDown()
    {
        if (isSelected)
        {
            Deselect();
        }
        else
        {
            Select();
        }
    }

    void Select()
    {
        isSelected = true;
        priceTextObject.SetActive(true);
        priceDisplay.text = $"Price: €{price}";

        // Add the item to the dictionary and update the receipt.
        if (!selectedItems.ContainsKey(gameObject.name))
        {
            selectedItems.Add(gameObject.name, price);
        }

        UpdateReceipt();

        ReceiptManager.Instance.AddToReceipt(price);
        selectedItemCount++;
    }

    void Deselect()
    {
        isSelected = false;
        priceDisplay.text = "";

        // Remove the item from the dictionary and update the receipt.
        if (selectedItems.ContainsKey(gameObject.name))
        {
            selectedItems.Remove(gameObject.name);
        }

        UpdateReceipt();

        priceTextObject.SetActive(false);
        ReceiptManager.Instance.RemoveFromReceipt(price);
        selectedItemCount--;
    }

    void UpdateReceipt()
    {
        // Clear the current receipt text.
        receiptText.text = "Selected Items:\n";

        // Regenerate the receipt based on the selected items.
        foreach (var item in selectedItems)
        {
            receiptText.text += $"{item.Key}: €{item.Value}\n";
        }
    }

    public static void HideAllPricing()
    {
        foreach (var item in allItems)
        {
            item.priceTextObject.SetActive(false);
        }

        if (receiptText != null)
        {
            receiptText.gameObject.SetActive(false);
        }
    }

    void DeselectWithoutRemovingPrice()
    {
        isSelected = false;
        priceDisplay.text = "";
    }

    void ToggleSelection()
    {
        isSelected = !isSelected;

        if (isSelected)
        {
            priceTextObject.SetActive(true);
            currentlySelected = this;
            priceDisplay.text = $"Price: €{price}";

            // Add to receipt dictionary and update receipt text.
            if (!selectedItems.ContainsKey(gameObject.name))
            {
                selectedItems.Add(gameObject.name, price);
            }

            UpdateReceipt();

            ReceiptManager.Instance.AddToReceipt(price);
        }
        else
        {
            priceTextObject.SetActive(false);
            priceDisplay.text = "";

            // Remove from receipt dictionary and update receipt text.
            if (selectedItems.ContainsKey(gameObject.name))
            {
                selectedItems.Remove(gameObject.name);
            }

            UpdateReceipt();

            ReceiptManager.Instance.RemoveFromReceipt(price);
            currentlySelected = null;
        }
    }

    public static void DeselectCurrent()
    {
        if (currentlySelected != null)
        {
            currentlySelected.Deselect();
            currentlySelected = null;
        }
    }

    public static string GetSelectedItemsList()
    {
        string itemList = "Selected Items:\n";

        foreach (var item in selectedItems)
        {
            itemList += $"{item.Key}: €{item.Value:F2}\n";
        }

        return itemList;
    }

    public static void ResetStaticFields()
    {
        currentlySelected = null;
        selectedItemCount = 0;
        receiptText = null;
        selectedItems.Clear();
        allItems.Clear();
    }
}
