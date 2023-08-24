using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDoListUpdater : MonoBehaviour
{
    public RawImage TickInsurance;
    public RawImage TickVisa;
    public RawImage TickAccomodation;
    public RawImage TickClothes;
    public RawImage TickFood;
    public RawImage TickLeapCard;
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.OnProgressUpdate += CompleteChallenge;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CompleteChallenge(int progress)
    {
        switch (progress)
        {
            case 1:
                TickInsurance.enabled = true;
                break;
            case 2:
                TickVisa.enabled = true;
                break;
            case 3:
                TickAccomodation.enabled = true;
                break;
            case 4:
                TickClothes.enabled = true;
                break;
            case 5:
                TickFood.enabled = true;
                break;
            case 6:
                TickLeapCard.enabled = true;
                break;
            default:
                break;
        }
    }
}
