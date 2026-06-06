using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] int slotIndex;
    [SerializeField] bool isRight = false;


    public static event Action ItemPlaced;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            RectTransform item = eventData.pointerDrag.GetComponent<RectTransform>();
           
           
            item.SetParent(transform, false);
            item.anchoredPosition = Vector2.zero;

      
            PartsSystem dragItem = eventData.pointerDrag.GetComponent<PartsSystem>();
            dragItem.SetDropped();
      
            PartsSystem partsSystem = GetComponentInChildren<PartsSystem>();
            if (partsSystem._count == slotIndex)
            {
                
                isRight = true;
                ItemPlaced?.Invoke();
            }
            
        }
    }
}