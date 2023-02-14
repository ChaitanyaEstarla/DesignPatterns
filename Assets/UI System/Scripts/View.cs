using UnityEngine;

namespace UI
{
    public abstract class View : MonoBehaviour
    {
        public abstract void Init();

        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
    }
}
