using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{

    public class MD_Slot_Tab : MonoBehaviour
    {
        [Space(10)]
        [Header("- Test")]
        [Header("- 기본 컬러")]
        [SerializeField] private Color nomalColor;

        [Header("- 클릭 시 컬러")]
        [SerializeField] private Color clickColor;

        [Header("- 탭 이미지 배열")]
        [SerializeField] private Image[] tabImageArr;

        [Header("- 탭 인벤토리")]
        [SerializeField] private MD_Inventory[] inventoryArr;

        private void Start()
        {
            Func_SetInventoryData();
        }
        
        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.26 </para>
        /// <para> 내    용 : 인벤토리 타입에 맞게 아이템을 불러오는 기능 </para>
        /// </summary>
        private void Func_SetInventoryData()
        {
            List<MD_ItemData> _allList = MD_XML.Instance.Func_GetItemData();

            for (int i = 0; i < inventoryArr.Length; i++)
            {
                List<MD_ItemData> _dataList = new List<MD_ItemData>();

                for (int j = 0; j < _allList.Count; j++)
                {
                    if (inventoryArr[i].inventoryType == _allList[j].data_Type)
                    {
                        _dataList.Add(_allList[j]);
                    }
                }

                inventoryArr[i].Func_LoadItemInformation(_dataList);
            }
        }

        public void Button_ClickTab(int _clickNum)
        {
            for (int i = 0; i < tabImageArr.Length; i++)
            {
                tabImageArr[i].color = nomalColor;
                inventoryArr[i].gameObject.SetActive(false);
            }

            tabImageArr[_clickNum].color = clickColor;
            inventoryArr[_clickNum].gameObject.SetActive(true);
        }
    }
}