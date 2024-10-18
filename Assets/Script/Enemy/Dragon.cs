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
    public class Dragon : IEnemy
    {
        const string resourceName = "Dragon";

        readonly static Vector3 AppearPosition = new Vector3(12f, -.5f, 0);
        readonly static Vector3 EnteredPosition = new Vector3(4f, -.5f, 0);

        GameObject m_enemy;
        string m_name;
        Color m_color;

        public string Name => m_name;
        public Color NameColor => m_color;

        public Dragon()
        {
            m_name = "ƒhƒ‰ƒSƒ“";
            m_color = Color.blue;
        }

        public async UniTask EnterRoom()
        {
            //“G‚ğ¶¬
            m_enemy = GameObject.Instantiate(Resources.Load<GameObject>(EnemyUtil.EnemyPrefabPath + resourceName), AppearPosition, Quaternion.identity);

            SoundManager.PlaySEWithLoop(SoundManager.SELabel.FootWalk);
            //“G‚ª•”‰®‚É“ü‚é
            await LMotion.Create(AppearPosition, EnteredPosition, 1f)
                .BindToPosition(m_enemy.transform);
            SoundManager.StopLoopSE();

        }

        public async UniTask ExitRoom()
        {
            //“G‚ª•”‰®‚©‚ço‚é
            await LMotion.Create(EnteredPosition, AppearPosition, 1f)
                .BindToPosition(m_enemy.transform);

            //“G‚ğíœ
            GameObject.Destroy(m_enemy);

        }
    }
}
