using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad20241013.Injection
{
    public class OpeningFactory : IOpeningFactory
    {
        ITalkManager m_talkManager;
        ISceneFader m_sceneFader;
        ITalkCharacter m_talkCharacter;

        List<TalkSource> m_talkSource;

        public OpeningFactory(ITalkManager talkManager, ISceneFader sceneFader, ITalkCharacter talkCharacter)
        {
            m_talkManager = talkManager;
            m_sceneFader = sceneFader;
            m_talkCharacter = talkCharacter;
        }

        public Opening CreateOpening()
        {
            m_talkSource = new List<TalkSource>();

            m_talkSource.Add(new TalkSource() { talkCharacter = m_talkCharacter, talkSentence = "(私はモンスターの医者。\nモンスターの言うことをしっかり聞いて、\n適切な魔具を渡さないとな)" });

            return new Opening(m_talkManager, m_sceneFader, m_talkSource);

        }
    }
}
