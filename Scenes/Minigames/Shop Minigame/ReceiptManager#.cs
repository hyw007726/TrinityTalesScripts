using UnityEngine;
using UnityEngine.UI;

public class ReceiptManager : MonoBehaviour
{
    public static ReceiptManager Instance; // Singleton pattern

    public Text totalReceiptDisplay; // Drag and drop your UI Text element for the total receipt
    private float totalCost = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetCurrentTotal()
    {
        return totalCost;
    }

    public void AddToReceipt(float price)
    {
        totalCost += price;
        UpdateReceiptDisplay();
    }

    public void RemoveFromReceipt(float price)
    {
        totalCost -= price;
        UpdateReceiptDisplay();
    }

    private void UpdateReceiptDisplay()
    {
        totalReceiptDisplay.text = $"Total: €{totalCost:F2}"; // Display the total with 2 decimal places
    }

    public void HideTotalReceiptDisplay()
    {
        totalReceiptDisplay.gameObject.SetActive(false);
    }

    private void Update()
    {
        // The following checks could be used for debugging purposes
        if (!totalReceiptDisplay.gameObject.activeInHierarchy)
        {
        
        }

        if (totalReceiptDisplay.color.a == 0)
        {
           
        }
    }
}
