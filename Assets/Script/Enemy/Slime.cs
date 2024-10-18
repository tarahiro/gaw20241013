using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitMotion;
using LitMotion.Extensions;
using UniRx;
using UnityEditor;
using gad20241013;

namespace gad20241013.Enemy
{
    public class Slime : IEnemy
    {
        const string resourceName = "Slime";

        readonly static Vector3 AppearPosition = new Vector3(12f, -2f, 0);
        readonly static Vector3 EnteredPosition = new Vector3(4f, -2f, 0);

        GameObject m_enemy;
        string m_name;
        Color m_color;

        public string Name => m_name;
        public Color NameColor => m_color;

        public Slime()
        {
            m_name = "スライム";
            m_color = Color.blue;
        }

        public async UniTask EnterRoom()
        {
            //敵を生成
            m_enemy = GameObject.Instantiate(Resources.Load<GameObject>(EnemyUtil.EnemyPrefabPath + resourceName), AppearPosition, Quaternion.identity);

            //敵が部屋に入る
            await LMotion.Create(AppearPosition, EnteredPosition, 1f)
                .BindToPosition(m_enemy.transform);

        }

        public async UniTask ExitRoom()
        {
            //敵が部屋から出る
            await LMotion.Create(EnteredPosition, AppearPosition, 1f)
                .BindToPosition(m_enemy.transform);

            //敵を削除
            GameObject.Destroy(m_enemy);

        }
    }
}
