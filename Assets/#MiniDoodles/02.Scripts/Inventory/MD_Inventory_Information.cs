using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.12.28 </para>
    /// <para> 내    용 : 인벤토리의 정보창 클래스 </para>
    /// </summary>
    public class MD_Inventory_Information : MonoBehaviour
    {
        [Header("- 아이템 이름 텍스트")]
        [SerializeField] private Text text_ItemName;

        [Header("- 아이템 설명 텍스트")]
        [SerializeField] private Text text_ItemDescription;

        [Header("- 아이템 이미지")]
        [SerializeField] private Image image_Item;

        [Header("- 아이템 데이터")]
        [SerializeField] private MD_ItemData itemData;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.28 </para>
        /// <para> 내    용 : 인벤토리의 정보창을 설정하고 활성화 하는 기능 </para>
        /// </summary>
        public void Func_SetInformation(MD_ItemData _data, Sprite _sprite)
        {
            itemData = _data;
            text_ItemName.text = itemData.data_Name;
            text_ItemDescription.text = itemData.data_Description;
            image_Item.sprite = _sprite;

            gameObject.SetActive(true);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.28 </para>
        /// <para> 내    용 : 인벤토리의 정보창을 비활성화 하는 기능 </para>
        /// 정보창의 투명BG에서 호출
        /// </summary>
        public void Button_DisableInformation()
        {
            gameObject.SetActive(false);
        }
    }
}