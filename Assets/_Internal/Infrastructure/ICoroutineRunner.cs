using System.Collections;
using UnityEngine;

namespace _Internal.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}