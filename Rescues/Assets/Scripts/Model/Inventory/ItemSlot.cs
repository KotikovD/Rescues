﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


namespace Rescues
{
    public class ItemSlot : MonoBehaviour, /*IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler,*/ IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        [SerializeField] Image image;

        //public event Action<ItemSlot> OnPointerEnterEvent;
        //public event Action<ItemSlot> OnPointerExitEvent;
        //public event Action<ItemSlot> OnRightClickEvent;
        public event Action<ItemSlot> OnBeginDragEvent;
        public event Action<ItemSlot> OnEndDragEvent;
        public event Action<ItemSlot> OnDragEvent;
        public event Action<ItemSlot> OnDropEvent;

        private Color _normalColor = Color.white;
        private Color _disabledColor = new Color(1, 1, 1, 0);
        private Color _dragColor = new Color(1, 1, 1, 0.5f);

        [SerializeField] ItemData _item;
        public ItemData Item
        {
            get { return _item; }
            set
            {
                _item = value;
                if (_item == null)
                {
                    image.color = _disabledColor;
                }
                else
                {
                    image.sprite = _item.Icon;
                    image.color = _normalColor;
                }
            }
        }

        protected virtual void OnValidate()
        {
            if (image == null)
            {
                image = GetComponent<Image>();
            }
        }

        public virtual bool CanReceiveItem(ItemData item)
        {
            return true;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Item != null) image.color = _dragColor;
            OnBeginDragEvent?.Invoke(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (Item != null) image.color = _normalColor;
            OnEndDragEvent?.Invoke(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnDragEvent?.Invoke(this);
        }

        public void OnDrop(PointerEventData eventData)
        {
            OnDropEvent?.Invoke(this);
        }

        //Если нужны будут тултипы при наведении, например, или что-то по клику, то можно реализовать эти интерфейсы:

        //public void OnPointerClick(PointerEventData eventData)
        //{
        //    
        //   OnRightClickEvent?.Invoke(this);
        //    
        //}

        //public void OnPointerEnter(PointerEventData eventData)
        //{
        //    OnPointerEnterEvent?.Invoke(this);
        //}

        //public void OnPointerExit(PointerEventData eventData)
        //{
        //    OnPointerExitEvent?.Invoke(this);
        //}


    }
}
