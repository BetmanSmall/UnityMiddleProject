using UnityEngine;
using Zenject;

public class InjectionTest : MonoBehaviour
{
    public ITest _test;

    [Inject]
    public void Init(ITest test)
    {
        _test = test;
    }

    private void Start()
    {
        _test.Echo();
    }
}