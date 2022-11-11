using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProbablePotato
{
    /// <summary>
    /// �X�e�[�^�X�������f��
    /// </summary>
    [System.Serializable]
    public class PotatoModel: IValueModel
    {
        public PotatoModel(float generateTime)
        {
            this.value = generateTime;
        }

        [SerializeField]
        private float value = 0.0f;

        public float Value { get => value; set => this.value = value; }
    }

}
