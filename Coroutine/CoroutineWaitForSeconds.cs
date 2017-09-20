using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coroutine
{
    public class CoroutineWaitForSeconds : CoroutineYieldInstruction
    {
        float m_waitTime;
        DateTime m_startTime;
        public CoroutineWaitForSeconds(float waitTime)
        {
            m_waitTime = waitTime;
            m_startTime = DateTime.Now;
        }
        public override bool isDone()
        {
            return (DateTime.Now - m_startTime).TotalSeconds >= m_waitTime;
        }
    }
}
