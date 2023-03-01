using System.Collections;

namespace Interfaces
{
    public interface IDestroyable
    {

        public abstract void DoDestroy();

        public abstract IEnumerator DoDelayedDestroy();
    }
}
