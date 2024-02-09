using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoxInvasion.Runtime.Utilities
{
    public class ThreadService
    {
        private readonly CoroutineRunner _coroutineRunner;
        private readonly List<Action> _executeOnMainThread = new();
        private readonly List<Action> _executeCopiedOnMainThread = new();
        private static bool _actionToExecuteOnMainThread;

        public ThreadService(CoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Initialize() =>
            _coroutineRunner.StartCoroutine(TickCoroutine());

        private IEnumerator TickCoroutine()
        {
            while (true)
            {
                UpdateMain();
                yield return new WaitForEndOfFrame();
            }
        }

        public void ExecuteInMainThread(Action action)
        {
            if (action == null)
            {
                Debug.Log("No action to execute on main thread!");
                return;
            }

            lock (_executeOnMainThread)
            {
                _executeOnMainThread.Add(action);
                _actionToExecuteOnMainThread = true;
            }
        }

        private void UpdateMain()
        {
            if (!_actionToExecuteOnMainThread) return;

            _executeCopiedOnMainThread.Clear();
            lock (_executeOnMainThread)
            {
                _executeCopiedOnMainThread.AddRange(_executeOnMainThread);
                _executeOnMainThread.Clear();
                _actionToExecuteOnMainThread = false;
            }

            foreach (var action in _executeCopiedOnMainThread) action();
        }
    }
}