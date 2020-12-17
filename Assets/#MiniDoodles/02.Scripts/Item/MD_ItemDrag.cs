﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.12.17 </para>
    /// <para> 내    용 : 아이템을 드래그 인터렉션 하는 클래스 </para>
    /// </summary>
    public class MD_ItemDrag : MonoBehaviour
    {
        private MD_Item item;               // 아이템
        private EventTrigger eventTrigger;  // 이벤트트리거
        private MD_Drag_ItemImage dragImage;        // 드래그 할 이미지
        private Camera cam;                 // 드래그 이미지를 카메라의 화면의 어디 위치에 나타낼지 알아야 해서 캐싱하는 메인카메라

        private MD_ItemData itemData;
        private bool isVoid;                // 아이템이 비어있는지 체크

        private void Awake()
        {
            // 이벤트트리거 캐싱
            eventTrigger = GetComponent<EventTrigger>();
            if (eventTrigger == null)
            {
                eventTrigger = gameObject.AddComponent<EventTrigger>();
            }

            // 아이템 캐싱
            item = GetComponent<MD_Item>();

            // 카메라 캐싱
            cam = Camera.main;
        }

        private void Start()
        {
            Func_SetTrigger();      // 이벤트트리거 설정
        }

        #region 설정

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.17 </para>
        /// <para> 내    용 : 이벤트 트리거를 설정하는 기능 </para>
        /// </summary>
        private void Func_SetTrigger()
        {
            // 다운
            EventTrigger.Entry _entryDown = new EventTrigger.Entry();
            _entryDown.eventID = EventTriggerType.PointerDown;
            _entryDown.callback.AddListener((data) =>
            {
                Func_ItemPointerDown();
            });
            eventTrigger.triggers.Add(_entryDown);

            // 클릭
            EventTrigger.Entry _entryClick = new EventTrigger.Entry();
            _entryClick.eventID = EventTriggerType.PointerClick;
            _entryClick.callback.AddListener((data) =>
            {
                Func_ItemClick();
            });
            eventTrigger.triggers.Add(_entryClick);

            // 드래그
            EventTrigger.Entry _entryDrag = new EventTrigger.Entry();
            _entryDrag.eventID = EventTriggerType.Drag;
            _entryDrag.callback.AddListener((data) =>
            {
                Func_ItemDrag();
            });
            eventTrigger.triggers.Add(_entryDrag);

            // 드랍
            EventTrigger.Entry _entryDrop = new EventTrigger.Entry();
            _entryDrop.eventID = EventTriggerType.Drop;
            _entryDrop.callback.AddListener((data) =>
            {
                Func_ItemDrop();
            });
            eventTrigger.triggers.Add(_entryDrop);

            // 업
            EventTrigger.Entry _entryUp = new EventTrigger.Entry();
            _entryUp.eventID = EventTriggerType.PointerUp;
            _entryUp.callback.AddListener((data) =>
            {
                Func_ItemPointerUp();
            });
            eventTrigger.triggers.Add(_entryUp);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.17 </para>
        /// <para> 내    용 : 드래그 할 이미지를 설정하는 기능 </para>
        /// </summary>
        public void Func_SetDragImage(MD_Drag_ItemImage _dragImage)
        {
            dragImage = _dragImage;
        }

        #endregion
        
        #region 포인터 다운 시 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.17 </para>
        /// <para> 내    용 : 아이템을 포인터 다운했을 때 호출되는 기능 </para>
        /// </summary>
        private void Func_ItemPointerDown()
        {
            Debug.Log("아이템 다운");
            itemData = item.itemData;
            isVoid = (itemData.data_ID == -1);  // 비어있는지 체크

            dragImage.gameObject.SetActive(true);
            dragImage.DragItemData = itemData;
        }

        #endregion

        #region 클릭 시 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.17 </para>
        /// <para> 내    용 : 아이템을 클릭했을 때 호출되는 기능 </para>
        /// </summary>
        private void Func_ItemClick()
        {
            if (isVoid)
            {
                return;
            }

            Debug.Log("정보 보기");
        }

        #endregion

        #region 드래그 시 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.17 </para>
        /// <para> 내    용 : 아이템을 드래그했을 때 호출되는 기능 </para>
        /// </summary>
        private void Func_ItemDrag()
        {
            if (isVoid)
            {
                return;
            }

            Debug.Log("아이템 드래그");

            Vector2 _dragPosition = Input.mousePosition;
            Vector2 _worldPosition = cam.ScreenToWorldPoint(_dragPosition);
            dragImage.transform.position = _worldPosition;
        }

        #endregion

        #region 다른 곳에 드랍했을 때 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.17 </para>
        /// <para> 내    용 : 아이템을 드랍했을 때 호출되는 기능 </para>
        /// </summary>
        private void Func_ItemDrop()
        {
            if (isVoid)
            {
                return;
            }

            Debug.Log("아이템 스왑");
            
        }

        #endregion

        #region 포인터 업했을 때 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.17 </para>
        /// <para> 내    용 : 아이템에서 손을 땠을 때 호출되는 기능 </para>
        /// </summary>
        private void Func_ItemPointerUp()
        {
            if (isVoid)
            {
                return;
            }

            Debug.Log("아이템 포인트 업");
            dragImage.gameObject.SetActive(false);
        }


        #endregion


    }
}