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
        public PotatoModel(float generateTime, string groupID)
        {
            this.value = generateTime;
            this.groupID = groupID;
        }

        /// <summary>
        /// ���ۂ̃X�e�[�^�X
        /// </summary>
        [SerializeField]
        private float value = 0.0f;

        /// <summary>
        /// ��������O���[�vID�A�������̃O���[�v���Ƃɓ���ID�ɂȂ�
        /// </summary>
        [SerializeField]
        private string groupID = "";

        public float Value { get => value; set => this.value = value; }
        public string GroupID { get => groupID; set => groupID = value; }
    }

}
