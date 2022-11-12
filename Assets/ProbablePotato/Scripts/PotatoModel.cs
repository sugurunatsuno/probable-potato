using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProbablePotato
{
    /// <summary>
    /// ステータスを持つモデル
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
        /// 実際のステータス
        /// </summary>
        [SerializeField]
        private float value = 0.0f;

        /// <summary>
        /// 所属するグループID、生成時のグループごとに同じIDになる
        /// </summary>
        [SerializeField]
        private string groupID = "";

        public float Value { get => value; set => this.value = value; }
        public string GroupID { get => groupID; set => groupID = value; }
    }

}
