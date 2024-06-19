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
    public bool isChosen = false;
    public AbilityManager.Ability ability;
    public Animator anim;
    public int numCalled;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        child.GetComponent<Canvas>().sortingOrder = child.GetComponent<Canvas>().sortingOrder = 1;
        rect.sizeDelta = new Vector2(111.7f, 180);
        anim.SetBool("isTriggered", true);
        AddNum();
    }

    public void AddNum()
    {
        numCalled++;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        child.GetComponent<Canvas>().sortingOrder = child.GetComponent<Canvas>().sortingOrder = 0;
        rect.sizeDelta = new Vector2(100, 157.57f);
        anim.SetBool("isTriggered", false);
        numCalled = 0;
    }

    public void NoNumCall()
    {
        numCalled = 0;
    }

    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        anim.SetBool("isTriggered", false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isChosen = true;
    }

    private void Update() {
        anim.enabled = true;
        if(numCalled > 1)
        {
            numCalled = 0;
            anim.SetBool("isTriggered", false);
        }

        if(numCalled == 0)
        {
            anim.SetBool("isTriggered", false);
        }
    }
}
