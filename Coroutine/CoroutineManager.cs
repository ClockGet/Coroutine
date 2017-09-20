using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
namespace Coroutine
{
    public class CoroutineManager
    {
        private static Lazy<CoroutineManager> _instance = new Lazy<CoroutineManager>(()=>new CoroutineManager(),LazyThreadSafetyMode.ExecutionAndPublication);
        private Timer timer = null;
        private CoroutineManager()
        {
            timer = new Timer(new TimerCallback(LateUpdate),null,0,20);
        }
        public static CoroutineManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        List<IEnumerator> m_enumerators = new List<IEnumerator>();
        List<IEnumerator> m_enumeratorsBuffer = new List<IEnumerator>();
        void LateUpdate(object state)
        {
            for(int i=0;i<m_enumerators.Count;i++)
            {
                CoroutineYieldInstruction yieldInstruction = null;
                if ((yieldInstruction = m_enumerators[i].Current as CoroutineYieldInstruction)!=null)
                {
                    if(!yieldInstruction.isDone())
                    {
                        continue;
                    }
                }
                if(!m_enumerators[i].MoveNext())
                {
                    m_enumeratorsBuffer.Add(m_enumerators[i]);
                    continue;
                }
            }
            for(int i=0;i<m_enumeratorsBuffer.Count;i++)
            {
                m_enumerators.Remove(m_enumeratorsBuffer[i]);
            }
            m_enumeratorsBuffer.Clear();
        }
        public void StartCoroutine(IEnumerator enumerator)
        {
            m_enumerators.Add(enumerator);
        }
    }
}
