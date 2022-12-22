using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Vendor/Item")]
public class VendorItem : ScriptableObject
{
 public CHealth bigPotion;
 public CHealth mediumPotion;
 public CHealth smallPotion;
 public int Cost;
}
