using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorPicker : MonoBehaviour, IPointerClickHandler
{
    public GameObject headSkin;
    public GameObject bodySkin;
    private Image imageComponent;
    private Texture2D texture;
    private void Start()
    {
        imageComponent = GetComponent<Image>();
        texture = imageComponent.sprite.texture;
        if (imageComponent == null)
        {
            Debug.LogError("Image component is null!");
        }
        else if (imageComponent.sprite == null)
        {
            Debug.LogError("Sprite is not set in the Image component!");
        }
        else
        {
            texture = imageComponent.sprite.texture;
            Debug.LogError(texture);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 localCursor;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(imageComponent.rectTransform, eventData.position, eventData.pressEventCamera, out localCursor))
        {
            int x = Mathf.Clamp((int)(localCursor.x * texture.width / imageComponent.rectTransform.sizeDelta.x), 0, texture.width - 1);
            int y = Mathf.Clamp((int)(localCursor.y * texture.height / imageComponent.rectTransform.sizeDelta.y), 0, texture.height - 1);

            Color pickedColor = texture.GetPixel(x, y);
            Color brownShade = new Color(0.16f, 0.14f, 0.125f);
            Color shadedColor = Color.Lerp(pickedColor, brownShade, 0.5f);
            // Do something with the pickedColor
            ChangeColor(headSkin, shadedColor);
            ChangeColor(bodySkin, shadedColor);
        }
    }


    public void ChangeColor(GameObject skin, Color color)
    {
        SkinnedMeshRenderer r = skin.GetComponent<SkinnedMeshRenderer>();
        if (r != null)
        {
            for (int i = 0; i < r.materials.Length; i++)
            {
                //Debug.Log(r.materials[i].name);
                if (r.materials[i].name == "ellie.skin (Instance)")
                {
                    Material mat = r.materials[i];
                    mat.color = color;
                    r.materials[i] = mat; // Reassign the material to the renderer
                }
            }
        }
    }
}
