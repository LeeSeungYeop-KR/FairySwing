using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{    
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.05.16</para>
    /// <para>내    용 : 아이템의 스크립트</para>
    /// </summary>
    public class MD_Item : MonoBehaviour
    {
        [Header("- 아이템의 이미지")]
        [SerializeField] private Image image_item;        // 아이템의 이미지

        [Header("- 아이템 개수 Text")]
        [SerializeField] private Text text_ItemNum;

        [Header("- 아이템 데이터")]
        public MD_ItemData itemData;
        
        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.15 </para>
        /// <para> 내    용 : 인벤토리 슬롯의 아이템 데이터를 설정하는 기능</para>
        /// </summary>
        public void Func_SetItemData(MD_ItemData _data)
        {
            itemData = _data;
            if (itemData.data_ID != -1)
            {
                Func_SetImage(_data.data_ID);           // 이미지 설정
                Func_SetItemCount(_data.data_Count);    // 아이템 개수
            }
            else
            {
                Func_VoidData();
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.17 </para>
        /// <para> 내    용 : 아이템 데이터가 비어있을 때 호출되는 기능</para>
        /// </summary>
        protected void Func_VoidData()
        {
            // 비어있는 아이템 이미지
            image_item.sprite = MD_ScriptableManager.Instance.Func_GetScriptable<MD_Inventory_Setting>().sprite_VoidItem;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.17 </para>
        /// <para> 내    용 : 아이템 데이터의 아이디로 아이템의 스프라이트를 선택하는 기능</para>
        /// </summary>
        protected void Func_SetImage(int _itemID)
        {
            image_item.sprite = MD_ScriptableManager.Instance.Func_GetScriptable<MD_Inventory_Setting>().Func_GetIDImage(_itemID);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.15 </para>
        /// <para> 내    용 : 아이템의 개수를 설정하는 기능</para>
        /// </summary>
        private void Func_SetItemCount(int _itemCount)
        {
            if (_itemCount <= 1)
            {
                text_ItemNum.gameObject.SetActive(false);
            }
            else
            {
                text_ItemNum.text = _itemCount.ToString();
                text_ItemNum.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.26 </para>
        /// <para> 내    용 : 아이템을 집었을 때 슬롯에 있는 아이템을 숨기는 기능</para>
        /// </summary>
        public void Func_HideItem()
        {
            // 이미지 숨기기
            image_item.sprite = MD_ScriptableManager.Instance.Func_GetScriptable<MD_Inventory_Setting>().sprite_VoidItem;

            // 텍스트 숨기기
            text_ItemNum.gameObject.SetActive(false);
        }
    }
}