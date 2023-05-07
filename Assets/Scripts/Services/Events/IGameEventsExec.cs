using Data;
using System;

namespace Services.Events
{
    public interface IGameEventsExec
    {
        event Action PlayerSelectedFalseCube;

        void OnGameStarted();
        void OnLevelLoaded();
        void OnLevelLose();
        void OnLevelWin();
        void OnPlayerSelectedCube(CubeActor cubeActor);
        void OnPlayerSelectedFalseCube();
        void OnPlayerSelectedTrueCube();
        void OnStartedSaveProgress(ProgressData progress);
    }
}