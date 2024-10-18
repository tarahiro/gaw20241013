using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013.Enemy;
using gad20241013.Talk;
using gad20241013.Item;

namespace gad20241013.Injection
{
    public class CycleFactory : ICycleFactory
    {
        ITalkManager m_talkManager;
        IItemSelector m_itemDialog;
        ItemProvider m_itemProvider;
        ITelop m_clearTelop;
        ITalkCharacter m_doctor;

        public CycleFactory(ITalkManager talkManager, IItemSelector itemDialog, ItemProvider itemProvider, ITelop clearTelop, ITalkCharacter doctor)
        {
            m_talkManager = talkManager;
            m_itemDialog = itemDialog;
            m_itemProvider = itemProvider;
            m_clearTelop = clearTelop;
            m_doctor = doctor;
        }

        public Cycle CreateCycle(int cycleCount)
        {
            Debug.Log("サイクル生成");
            switch (cycleCount)
            {
                case 0:
                    return CreateSlimeCycle();
                case 1:
                    Debug.Log("ゴーストのサイクル生成");
                    return CreateGhostCycle();
                case 2:
                    Debug.Log("ドラゴンのサイクル生成");
                    return CreateDragonCycle();

                default:
                    Debug.Log("デバッグ用サイクル生成");
                    return CreateFakeCycle();
            }
        }

        Cycle CreateSlimeCycle()
        {
            var monster = new Slime();

            var talkSourceListBeforeSelectItem = new List<TalkSource>();
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "どうされましたか？" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = monster, talkSentence = "すっごく身体が熱いスラ…\r\n溶けちゃいそうスラ…\r\nぽよぽよ。" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "いつごろからですか？" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = monster, talkSentence = "2日前、勇者パーティに出くわして…\r\n逃げる時に、炎の魔法が顔に食い込んだスラ。\r\nそのときからスラ。ぽよょ〜" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "体温は…10.2℃。確かに高めですね。\r\nそれでは、治せる魔具をお出ししましょう。" });

            var talkSourceListAfterSelectItem = new List<TalkSource>();
            talkSourceListAfterSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "こちらをどうぞ。" });

            var talkSourceListWhenFailed = new List<TalkSource>();
            talkSourceListWhenFailed.Add(new TalkSource() { talkCharacter = monster, talkSentence = "これ、ぽよが使って大丈夫なやつスラ？\n違うの出してほしいスラ…" });

            var talkSourceListWhenCleared = new List<TalkSource>();
            talkSourceListWhenCleared.Add(new TalkSource() { talkCharacter = monster, talkSentence = "うぴゃっ！？　つめたいスラ…\r\nあれ、身体が楽になってきたスラ！\r\nぽよんぽ！" });
            talkSourceListWhenCleared.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "使用中の魔具が身体から出ないように、\r\n今日は激しい戦闘は控えてください。\r\nお大事にどうぞ。" });

            return new Cycle(m_talkManager, m_itemDialog, monster, m_itemProvider.GetItem(1),m_clearTelop, talkSourceListBeforeSelectItem, talkSourceListAfterSelectItem, talkSourceListWhenCleared, talkSourceListWhenFailed);

        }

        Cycle CreateGhostCycle()
        {
            var monster = new Ghost();

            var talkSourceListBeforeSelectItem = new List<TalkSource>();
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = monster, talkSentence = "ひゅ〜どろ〜……" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "どこが痛みますか？" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = monster, talkSentence = "足が痛いバケェ…\r\n足なんてあったはずないのに、\r\n昔はあった気がするんドロ…" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "なるほど…。" });

            var talkSourceListAfterSelectItem = new List<TalkSource>();
            talkSourceListAfterSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "こちらをどうぞ。" });

            var talkSourceListWhenFailed = new List<TalkSource>();
            talkSourceListWhenFailed.Add(new TalkSource() { talkCharacter = monster, talkSentence = "これ、ドロが使ったら成仏しそうバケ。\n違うのにしてほしいバケ。" });

            var talkSourceListWhenCleared = new List<TalkSource>();
            talkSourceListWhenCleared.Add(new TalkSource() { talkCharacter = monster, talkSentence = "鏡の中に…ドロの…足が…見える？\r\nあれ、痛くないバケ！" });
            talkSourceListWhenCleared.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "毎日5分くらい、この鏡を見るようにしてください。\r\n1週間もあれば治りますよ。\r\nお大事に。" });

            return new Cycle(m_talkManager, m_itemDialog, monster, m_itemProvider.GetItem(3), m_clearTelop, talkSourceListBeforeSelectItem, talkSourceListAfterSelectItem, talkSourceListWhenCleared, talkSourceListWhenFailed);

        }

        Cycle CreateDragonCycle()
        {
            var dragon = new Dragon();
            var slime = new Slime();

            var talkSourceListBeforeSelectItem = new List<TalkSource>();
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = dragon, talkSentence = "医者なんて来てもムダドラァァ…" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = slime, talkSentence = "このお医者様はすごいスラ！\r\nぽよの病気もすぐ治してくれたスラ！" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "どうされましたか？" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = dragon, talkSentence = "どうもしないドラァァ…\r\nお前に話すことなど無いドラァ…" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = slime, talkSentence = "ドラゴンくん、剣が刺さってから変スラ。\r\n朝に会うと普通スラ、でも昼、夜になると元気が無いスラ…\r\nあと、歩くたびに変な音がするぽよ。" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = dragon, talkSentence = "おい、勝手に言うなドラァァ！　ァァ…。" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "刺されたときの状況…\r\nいや、どんな勇敢な戦いをしたか教えてくれませんか？" }); 
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = dragon, talkSentence = "…そこまで言うなら教えてやってもいいドラ！" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = dragon, talkSentence = "テーンマウン山の頂で、勇者パーティを迎え打ったドラ！\r\n勇者とか戦士と遊んでやってる間に、忍び寄った盗賊に刺されたドラァ……\r\nもちろんその後、全員教会送りにしてやったドラァ！　ドラァ…" });
            talkSourceListBeforeSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "ふむ…お待ちください。" });


            var talkSourceListAfterSelectItem = new List<TalkSource>();
            talkSourceListAfterSelectItem.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "こちらをどうぞ。" });

            var talkSourceListWhenFailed = new List<TalkSource>();
            talkSourceListWhenFailed.Add(new TalkSource() { talkCharacter = dragon, talkSentence = "そんなもの、ドラの身体に近づけるなドラァ！" });

            var talkSourceListWhenCleared = new List<TalkSource>();
            talkSourceListWhenCleared.Add(new TalkSource() { talkCharacter = dragon, talkSentence = "おお！　身体が軽いドラァ！" });
            talkSourceListWhenCleared.Add(new TalkSource() { talkCharacter = slime, talkSentence = "やっぱりすごいお医者様スラ！" });
            talkSourceListWhenCleared.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "それでは、後は背中のポイズンダガーを抜いて…" });
            talkSourceListWhenCleared.Add(new TalkSource() { talkCharacter = dragon, talkSentence = "これは抜かないドラァ！\r\n闘いの勲章ドラァ！！\r\n" });
            talkSourceListWhenCleared.Add(new TalkSource() { talkCharacter = m_doctor, talkSentence = "(まあ…ダガーの毒も抜けてるだろうし、いいか…)" });

            return new Cycle(m_talkManager, m_itemDialog, dragon, m_itemProvider.GetItem(6), m_clearTelop, talkSourceListBeforeSelectItem, talkSourceListAfterSelectItem, talkSourceListWhenCleared, talkSourceListWhenFailed);

        }
        Cycle CreateFakeCycle()
        {
            var monster = new Slime();
            var talkSourceList = new List<TalkSource>();
            talkSourceList.Add(new TalkSource() { talkCharacter = monster, talkSentence = "テスト91" });
            talkSourceList.Add(new TalkSource() { talkCharacter = monster, talkSentence = "テスト92" });
            return new Cycle(m_talkManager, m_itemDialog, monster, null, m_clearTelop, talkSourceList, null, null, null);

        }
    }
}
