using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProbablePotato
{
    /// <summary>
    /// 値を持つモデルのインターフェース
    /// </summary>
    public interface IValueModel
    {
        float Value { get; set; }
    }

}

