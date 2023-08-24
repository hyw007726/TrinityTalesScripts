using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CursorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Texture2D cursorTexture; // assign your cursor texture in the inspector
    private bool allowCursorChange = true; // boolean flag to control cursor change
    private Vector2 hotspot;

    private void Start()
    {
        Vector2 hotspot = new Vector2(cursorTexture.width/2, cursorTexture.height / 2);
        if (EventSystem.current.IsPointerOverGameObject(gameObject.GetInstanceID())&&allowCursorChange)
        {
            Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
        }
    }
    private void OnMouseEnter()
    {
     
        if (allowCursorChange)
        {
            Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
        }

    }

    private void OnMouseExit()
    {
        // Reset the cursor when the mouse leaves the object
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseDown()
    {
        //Debug.Log(gameObject.name);
        if (allowCursorChange)
        {
            Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
        }
    
    }
    private void OnMouseUp()
    {

        //if (!(gameObject.GetComponent<Button>()))
        //{
        //    EnableCursorChange();
        //}
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    
        if (allowCursorChange)
        {

           
            GameObject target = GameObject.Find("Dialogue");
            if (target != null)
            {

                DialogueController dialogueController = target.GetComponent<DialogueController>();
            
                if (dialogueController != null && dialogueController.currentDialogue == 0 && gameObject.name == "PrevButton")
                {
         
                    return;
                }
            }

            Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
        }
        else
        {
            
            if (gameObject.name == "InsuranceLink")
            {
                Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);

            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        // Reset the cursor when the mouse leaves the object
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
    }

    public void DisableCursorChange()
    {
        allowCursorChange = false;
        // Reset the cursor
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // This function can be called when you want to enable cursor change again
    public void EnableCursorChange()
    {
        allowCursorChange = true;
    }
    private void OnDestroy()
    {
        // Reset the cursor when the object is destroyed
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
