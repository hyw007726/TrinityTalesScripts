using UnityEngine;
using UnityEngine.UI;

public class CheckoutSystem : MonoBehaviour
{
    public Button checkoutButton; // Drag and drop your checkout button from the Unity Editor
    public Text totalPriceText; // Drag and drop the Text element inside the CongratulationsCanvas that displays the total price
    public GameObject congratulationsCanvas; // Drag and drop the CongratulationsCanvas from the Unity Editor to this variable
    public Text itemListText; // Drag and drop the ItemListText (inside CongratulationsCanvas) from the Unity Editor to this variable


    private void Start()
    {
        // Initially hide the checkout button
        checkoutButton.gameObject.SetActive(false);

        // Initially hide the congratulations canvas
        congratulationsCanvas.SetActive(false);
    }

    private void Update()
    {
        // If 5 items are selected, show the checkout button, otherwise hide it
        if (SelectableFood.selectedItemCount >= 5)
        {
            checkoutButton.gameObject.SetActive(true);
        }
        else
        {
            checkoutButton.gameObject.SetActive(false);
        }
    }

    public void OnCheckoutButtonClicked()
    {
        // Hide the checkout button
        checkoutButton.gameObject.SetActive(false);

        // Get the total amount from ReceiptManager
        float totalAmount = ReceiptManager.Instance.GetCurrentTotal();

        // Show the congratulations canvas and set the total price
        totalPriceText.text = string.Format("€{0:F2}", totalAmount);
        PlayerPrefs.SetString("bill", totalPriceText.text);
        congratulationsCanvas.SetActive(true);

        // Hide individual pricing and list of selected foods
        SelectableFood.HideAllPricing();

        // Hide the total receipt display from ReceiptManager
        ReceiptManager.Instance.HideTotalReceiptDisplay();

        // Hide existing UI elements
        // You might need methods from other scripts to hide individual pricing texts, etc.
        ReceiptManager.Instance.HideTotalReceiptDisplay();
        checkoutButton.gameObject.SetActive(false);
        // Note: If there are other UI elements, add code to hide them here.

        // Update the itemListText with the selected items and their prices
        itemListText.text = SelectableFood.GetSelectedItemsList();

        // Show the CongratulationsCanvas
        congratulationsCanvas.SetActive(true);
    }
}
