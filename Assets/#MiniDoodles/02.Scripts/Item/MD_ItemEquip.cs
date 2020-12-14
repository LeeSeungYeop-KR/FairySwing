using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{

    public class MD_ItemEquip : MD_Item
    {
        [Header("- Equipment Value")]
        [SerializeField] private int attack;
        [SerializeField] private int magic;
        [SerializeField] private int attackDefence;
        [SerializeField] private int magicDefence;

    }
}