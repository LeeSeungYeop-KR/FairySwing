using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.12.15 </para>
    /// <para> 내    용 : 인벤토리 클래스 </para>
    /// </summary>
    public class MD_Inventory : MonoBehaviour
    {
        [Header("- 인벤토리 타입")]
        [SerializeField] protected ItemType inventoryType;

        [Header("- 슬롯을 모으는 오브젝트의 Transfrom")]
        [SerializeField] private Transform slotPool;

        [Header("- 슬롯 리스트")]
        [SerializeField] protected List<MD_Slot> slotList;     // 슬롯 리스트

        protected virtual void Start()
        {
            Func_LoadItemInformation();
        }


        #region 아이템 로드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.16 </para>
        /// <para> 내    용 : 인벤토리 타입에 맞게 아이템을 불러오는 기능 </para>
        /// </summary>
        private void Func_LoadItemInformation()
        {
            List<MD_ItemData> _itemDataList = MD_XML.Instance.Func_GetItemData();

            Func_AddSlot(15);      // 아이템 개수 만큼 슬롯 늘리기
            //Func_AddSlot(_itemDataList.Count);      // 아이템 개수 만큼 슬롯 늘리기

            //for (int i = 0; i < _itemDataList.Count; i++)
            //{

            //}
        }

        private void Func_AddSlot(int _itemNum)
        {
            if (slotList.Count < _itemNum)
            {
                GameObject _slotPrefab = MD_ScriptableManager.Instance.Func_GetScriptable<MD_Inventory_Setting>().prefab_InventorySlot;
                int _excessNum = _itemNum - slotList.Count;     // 아이템 초과 개수
                Debug.Log("아이템 초과 개수 : " + _excessNum);
                float addNum = (float)_excessNum + (float)(4 - 1) / 4f;
                Debug.Log("더해야 할 개수 : " + addNum);
            }
        }

        #endregion
    }
}