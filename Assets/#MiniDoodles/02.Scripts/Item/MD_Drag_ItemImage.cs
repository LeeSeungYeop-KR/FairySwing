using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{

    public class MD_Drag_ItemImage : MonoBehaviour
    {
        [Header("- 드래그 중인 아이템의 데이터")]
        private MD_ItemData itemData;
        public MD_ItemData DragItemData
        {
            get { return itemData; }
            set
            {
                itemData = value;
                Func_SetImage();
            }
        }

        [Header("- 아이템 이미지")]
        [SerializeField] private Image imageItem;
        Vector3 firstPos;

        private void Awake()
        {
            firstPos = transform.position;
        }

        private void OnDisable()
        {
            transform.position = firstPos;
        }

        private void Func_SetImage()
        {
            if (itemData.data_ID != -1)
            {
                imageItem.sprite = MD_ScriptableManager.Instance.Func_GetScriptable<MD_Inventory_Setting>().Func_GetIDImage(itemData.data_ID);
            }
        }

    }
}