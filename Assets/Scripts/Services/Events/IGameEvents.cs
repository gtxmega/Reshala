using Data;
using System;

namespace Services.Events
{
    public interface IGameEvents
    {
        event Action GameStarted;
        event Action LevelLoaded;
        event Action<ProgressData> StartedSaveProgress;
        event Action<CubeActor> PlayerSelectedCube;
        event Action PlayerSelectedTrueCube;
        event Action PlayerSelectedFalseCube;
        event Action LevelWin;
        event Action LevelLose;
    }
}