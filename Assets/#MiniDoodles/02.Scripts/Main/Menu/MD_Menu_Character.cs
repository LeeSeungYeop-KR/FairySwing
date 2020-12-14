using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.11.18 </para>
    /// <para> 내    용 : 캐릭터 메뉴에 대한 클래스 </para>
    /// </summary>
    public class MD_Menu_Character : MonoBehaviour
    {
        [Header("- 캐릭터 카드를 모아놓은 객체")]
        [SerializeField] private Transform cardPool;

        [Header("- 캐릭터 카드 리스트")]
        [SerializeField] private List<MD_Character_Illustration> characterList;

        private void OnEnable()
        {
            Func_LoadCharacterCardInformation();    // XML에 있는 캐릭터 카드 정보 불러오기
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.11 </para>
        /// <para> 내    용 : XML에 있는 캐릭터 카드 정보 불러오는 기능 </para>
        /// </summary>
        private void Func_LoadCharacterCardInformation()
        {

        }

    }
}