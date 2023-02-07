using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ExtendedButton : Button
{
    [SerializeField] private UnityEvent _selectedEvent;
    [SerializeField] private UnityEvent _deselectedEvent;

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        _selectedEvent.Invoke();
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        _deselectedEvent.Invoke();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        _selectedEvent.Invoke();

    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        _deselectedEvent.Invoke();

    }
}
