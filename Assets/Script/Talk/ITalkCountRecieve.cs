using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad20241013.Talk.Assets.Script.Talk
{
    public interface ITalkCountRecieve
    {
        public void SetText(string text);

        public void End();
    }
}
