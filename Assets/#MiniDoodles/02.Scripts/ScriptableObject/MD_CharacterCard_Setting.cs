using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{
    [CreateAssetMenu(fileName ="CharacterCard", menuName = "MiniDoodles/CharacterCard", order = int.MaxValue)]
    public class MD_CharacterCard_Setting : MD_BaseScriptableObject
    {
        [Header("- 캐릭터의 별 프리팹")]
        public GameObject prefab_Star;

        [Header("- 캐릭터 스프라이트 배열")]
        public Sprite[] sprite_CharacterArr;
    }
}