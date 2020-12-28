using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.12.28 </para>
    /// <para> 내    용 : 프로그램의 공통적으로 쓰이는 데이터를 관리하는 클래스 </para>
    /// </summary>
    public class MD_DataManager : MD_Singlton<MD_DataManager>
    {
        /* 만들어야 할 것
            - 변수
            1. 아이템 리스트
            2. 무기 리스트
            3. 헬멧 리스트
            4. 갑옷 리스트
            5. 장갑 리스트
            6. 신발 리스트
            7. 기타 리스트
            8. 캐릭터 리스트

            - 메서드
            1. 아이템 리스트 불러오기
            2. 무기 리스트 불러오기
            3. 헬멧 리스트 불러오기
            4. 갑옷 리스트 불러오기
            5. 장갑 리스트 불러오기
            6. 신발 리스트 불러오기
            7. 기타 리스트 불러오기
            8. 캐릭터 리스트 불러오기

            9. 플레이어의 아이템 불러오기
            10. 플레이어의 아이템 저장
        */

        #region 변수

        [Header("- 아이템 리스트")]
        [SerializeField] private List<Dictionary<string, object>> itemList;

        #endregion


        private void Start()
        {
            Func_LoadData();
        }

        #region 불러오기 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.28 </para>
        /// <para> 내    용 : 프로그램의 공통적으로 쓰이는 데이터를 불러오는 기능 </para>
        /// </summary>
        private void Func_LoadData()
        {
            Func_LoadItemList();        // 아이템 리스트 불러오기
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.28 </para>
        /// <para> 내    용 : 아이템 데이터를 불러오는 기능 </para>
        /// </summary>
        private void Func_LoadItemList()
        {
            itemList = MD_CSVManager.Read(MD_PathDefine.CSV_ItemListPath);
        }

        #endregion

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.28 </para>
        /// <para> 내    용 : 플레이어가 가지고 있는 아이템 데이터를 불러오는 기능 </para>
        /// </summary>
        public List<MD_ItemData> Func_GetPlayerItemList()
        {
            List<MD_ItemData> _playerItemList = MD_XML.Instance.Func_GetItemData();

            for (int i = 0; i < _playerItemList.Count; i++)
            {
                for (int j = 0; j < itemList.Count; j++)
                {
                    if (_playerItemList[i].data_ID == (int)itemList[j]["id"])
                    {
                        MD_ItemData _itemData = new MD_ItemData();                          // 리스트에 있는 구조체를 변형하기 위해 할당
                        _itemData.data_ID = (int)itemList[j]["id"];                         // 아이템 아이디
                        _itemData.data_Name = itemList[j]["name"].ToString();               // 아이템 이름
                        _itemData.data_Description = itemList[j]["explanation"].ToString(); // 아이템 설명
                        _itemData.data_Type = (TYPE_ITEM)(int)itemList[j]["type"];          // 아이템 타입
                        _itemData.data_Count = _playerItemList[i].data_Count;               // 플레이어가 가지고있는 아이템 개수

                        _playerItemList[i] = _itemData;
                        break;
                    }
                }
            }

            return _playerItemList;
        }
    }
}