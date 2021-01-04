using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{

    public class MD_Slot_Tab : MonoBehaviour
    {
        [Header("- 기본 컬러")]
        [Header("- Test")]
        [SerializeField] private Color nomalColor;

        [Header("- 클릭 시 컬러")]
        [SerializeField] private Color clickColor;

        [Header("- 탭 이미지 배열")]
        [Space(20)]
        [SerializeField] private Image[] tabImageArr;

        [Header("- 탭 인벤토리")]
        [SerializeField] private MD_Inventory[] inventoryArr;

        private void Start()
        {
            Func_SetInventoryData();        // 플레이어의 인벤토리 데이터 설정
        }
        
        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.26 </para>
        /// <para> 내    용 : 인벤토리 타입에 맞게 아이템을 불러오는 기능 </para>
        /// </summary>
        private void Func_SetInventoryData()
        {
            List<MD_ItemData> _allList = MD_DataManager.Instance.Func_GetPlayerItemList();

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

            MD_PlayManager.Instance.Func_InitItemSwap();
            tabImageArr[_clickNum].color = clickColor;
            inventoryArr[_clickNum].gameObject.SetActive(true);
        }
    }
}