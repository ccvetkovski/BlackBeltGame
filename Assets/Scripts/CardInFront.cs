using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;

public class CardInFront : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject child;
    private RectTransform rect;
    public GameObject abManager;
    public AbilityManager.Ability ability;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("Hovering over.");
        child.GetComponent<Canvas>().sortingOrder = child.GetComponent<Canvas>().sortingOrder = 1;
        rect.sizeDelta = new Vector2(111.7f, 180);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        child.GetComponent<Canvas>().sortingOrder = child.GetComponent<Canvas>().sortingOrder = 0;
        rect.sizeDelta = new Vector2(100, 157.57f);
    }

    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        abManager.GetComponent<AbilityManager>().RemoveAbility(ability);
        Destroy(gameObject);
    }
}
