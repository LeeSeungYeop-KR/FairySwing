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
        public TYPE_ITEM inventoryType;

        [Header("- 슬롯을 모으는 오브젝트의 Transfrom")]
        [SerializeField] private int rowSlotNum = 4;

        [Header("- 슬롯을 모으는 오브젝트의 Transfrom")]
        [SerializeField] private MD_ScrollView slotPool;

        [Header("- 슬롯 리스트")]
        [SerializeField] protected List<MD_Slot> slotList;     // 슬롯 리스트

        [Header("- 아이템 드래그 이미지")] 
        [SerializeField] protected MD_Drag_ItemImage itemDragOBJ;      // 아이템 드래그 이미지
        
        #region 아이템 로드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.16 </para>
        /// <para> 내    용 : 타입에 맞는 아이템데이터를 받아서 슬롯을 설정하고 각 슬롯에 아이템을 저장하는 기능 </para>
        /// </summary>
        public void Func_LoadItemInformation(List<MD_ItemData> _dataList)
        {
            List<MD_ItemData> _itemDataList = _dataList;

            if (Func_AddSlotAndCheckSlot(_itemDataList.Count))      // 아이템 개수 만큼 슬롯 늘리기
            {
                // 아이템이 슬롯보다 많음
                for (int i = 0; i < _itemDataList.Count; i++)
                {
                    slotList[i].Func_SetSlotData(_itemDataList[i], itemDragOBJ);
                }
            }
            else
            {
                // 아이템이 슬롯보다 적음
                for (int i = 0; i < slotList.Count; i++)
                {
                    if (i <= _itemDataList.Count - 1)
                    {
                        slotList[i].Func_SetSlotData(_itemDataList[i], itemDragOBJ);
                    }
                    else
                    {
                        MD_ItemData _voidData = new MD_ItemData();
                        _voidData.data_ID = -1;
                        _voidData.data_Type = inventoryType;

                        slotList[i].Func_SetSlotData(_voidData, itemDragOBJ);
                    }
                }
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.17 </para>
        /// <para> 내    용 : 매개변수에 따라 슬롯을 4개씩 더 늘려주는 기능과 아이템이 슬롯보다 더 많은지 체크하는 기능 </para>
        /// </summary>
        /// <param name="_itemNum">아이템의 개수</param>
        /// <returns>아이템이 슬롯보다 많은지 체크</returns>
        private bool Func_AddSlotAndCheckSlot(int _itemNum)
        {
            // 현재 슬롯보다 많을 때
            if (slotList.Count < _itemNum)
            {
                GameObject _slotPrefab = MD_ScriptableManager.Instance.Func_GetScriptable<MD_Inventory_Setting>().prefab_InventorySlot;
                int _excessNum = _itemNum - slotList.Count;     // 아이템 초과 개수
                int addNum = ((_excessNum + (rowSlotNum - 1)) / rowSlotNum) * rowSlotNum;
                Debug.Log("슬롯 추가 개수 : " + addNum);

                for (int i = 0; i < addNum; i++)
                {
                    MD_Slot _slot = Instantiate(_slotPrefab, slotPool.transform).GetComponent<MD_Slot>();

                    slotList.Add(_slot);
                }

                slotPool.Func_SetRect();

                return true;
            }

            return false;
        }

        #endregion
    }
}