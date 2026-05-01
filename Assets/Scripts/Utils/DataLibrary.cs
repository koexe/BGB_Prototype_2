using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLibrary
{

}

public class WeaponInfo
{
    public int weaponCode;
    public string weaponName;
    public float atk;
    public float ats;
    public float reload;
    public float mag;
    public float crit;
    public float critMag;
}

public class PerkInfo
{
    public int perkCode;
    public string perkName;
    public string perkDescription;
    public StatBlock[] perkStat;
    public PerkType perkType;
}
public enum PerkType
{
    Perk = 0,
    Option = 1,
}
public enum RoomType
{
    Start = 0,
    NomalMonster = 1,
    EliteMonster = 2,
    Shop = 3,
    Boss = 4
}

public enum StatType
{
    //Base
    Atk = 1,
    Ats = 2,
    ReloadTime = 3,
    Mag = 4,
    Crit = 5,
    CritMag = 6,
    BulletAmount = 7,
    Ricochet = 8,

    //Additional
    Wound = 101,
    Adrenaline = 102,
    ComboAttack = 103,
    Contempt = 104,
    ExplodeCorps = 105,
    TaticalSlide = 106,

}

public enum StatSign
{
    Static = 0,
    Constant = 1,
    Percentage = 2,
}

public enum EnemyType
{
    BoomMushroom = 1,
    Blindmaw = 2,
}
