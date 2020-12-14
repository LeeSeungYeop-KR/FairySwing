using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <para>작 성 자 : 이승엽</para>
/// <para>작 성 일 : 2020.08.09</para>
/// <para>내    용 : 캐릭터를 보는 뷰의 크기를 정해주는 스크립트</para>
/// </summary>
public class MD_CharacterView : MonoBehaviour
{
    [Header("- UI Value")]
    [SerializeField] private float originalNum = 370f;

    // Start is called before the first frame update
    void OnEnable()
    {
        RectTransform _rect = GetComponent<RectTransform>();
        int _num = transform.childCount;

        if (_num <= 9)
        {
            _rect.sizeDelta = new Vector2(0, 1120f);
        }
        else
        {
            float _value = (_num - 9 + 2) / 3 * originalNum;
            _rect.sizeDelta = new Vector2(0, 1120f + _value);
        }
    }

}
