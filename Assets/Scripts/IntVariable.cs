using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class IntVariable : ScriptableObject
{
    //Toutes les variables accessibles dans l'inspector
    #region Exposed
    public int _value;
    #endregion
}
