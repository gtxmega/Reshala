using Data;
using System;
using UnityEngine;

namespace Services.Events
{
    public class GameEvents : MonoBehaviour, IGameEvents, IGameEventsExec
    {
        public event Action LevelLoaded;
        public event Action GameStarted;
        public event Action LevelWin;
        public event Action LevelLose;

        public event Action<ProgressData> StartedSaveProgress;

        public event Action<CubeActor> PlayerSelectedCube;
        public event Action PlayerSelectedTrueCube;
        public event Action PlayerSelectedFalseCube;

        public void OnLevelLoaded() => LevelLoaded?.Invoke();
        public void OnGameStarted() => GameStarted?.Invoke();

        public void OnStartedSaveProgress(ProgressData progress) => StartedSaveProgress?.Invoke(progress);

        public void OnPlayerSelectedCube(CubeActor cubeActor) => PlayerSelectedCube?.Invoke(cubeActor);
        public void OnPlayerSelectedTrueCube() => PlayerSelectedTrueCube?.Invoke();
        public void OnPlayerSelectedFalseCube() => PlayerSelectedFalseCube?.Invoke();

        public void OnLevelWin() => LevelWin?.Invoke();

        public void OnLevelLose() => LevelLose?.Invoke();
    }
}