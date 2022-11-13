using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace ProbablePotato 
{
    /// <summary>
    /// potato�I�u�W�F�N�g�\���p�N���X
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
