using gad20241013.SceneFader;
using gad20241013.Talk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad20241013.Injection
{

    public class EndingFactory : IEndingFactory
    {
        ITalkManager m_talkManager;
        ISceneFader m_sceneFader;
        ITelop m_telop;
        ITalkCharacter m_talkCharacter;

        List<TalkSource> m_talkSource;

        public EndingFactory(ITalkManager talkManager, ISceneFader sceneFader, ITelop telop, ITalkCharacter talkCharacter)
        {
            m_talkManager = talkManager;
            m_sceneFader = sceneFader;
            m_telop = telop;
            m_talkCharacter = talkCharacter;
        }

        public Ending CreateEnding()
        {

            m_talkSource = new List<TalkSource>();

            m_talkSource.Add(new TalkSource() { talkCharacter = m_talkCharacter, talkSentence = "(今日の診察は無事おわった。\n明日はどんなモンスターが来るかな…)" });

            return new Ending(m_talkManager, m_sceneFader,m_telop, m_talkSource);
        }
    }
}
