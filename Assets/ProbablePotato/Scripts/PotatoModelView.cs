using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace ProbablePotato 
{
    /// <summary>
    /// potatoオブジェクト表示用クラス
    /// </summary>
    public class PotatoModelView : MonoBehaviour
    {
        [SerializeField]
        PotatoModel model;

        public void Construct(PotatoModel model)
        {
            this.model = model;
        }
    }

}
