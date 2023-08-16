using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHVInput
{
    /// <summary>
    /// -1(left) 0(none) 1(right)
    /// </summary>
    /// <returns></returns>
    public int GetHorizontalAxis();

    /// <summary>
    /// -1(bottom) 0(none) 1(top)
    /// </summary>
    /// <returns></returns>
    public int GetVerticalAxis();
}
