using Data;
using Services.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Services.Quest
{
    [System.Serializable]
    public class QuestData
    {
        public CubeActor A;
        public CubeActor B;

        public QuestData(CubeActor a, CubeActor b) 
        {
            A = a;
            B = b;
        }
    }

    public class SectionQuest
    {
        public CubeActor TargetCube;
        public string QuestText;
        public int Result;
    }

    public class QuestsService : MonoBehaviour
    {
        [SerializeField] private List<QuestData> _questDatas;

        private List<SectionQuest> _sectionQuests = new();

        private int _questIndex;

        private IGameEvents _gameEvents;
        private IGameEventsExec _gameEventsExec;
        private System.Random _random;

        [Inject]
        private void Construction(IGameEvents gameEvents, IGameEventsExec gameEventsExec)
        {
            _gameEvents = gameEvents;
            _gameEventsExec = gameEventsExec;

            _gameEvents.LevelLoaded += OnLevelLoaded;
            _gameEvents.PlayerSelectedCube += OnPlayerSelectedCube;
        }

        private void OnLevelLoaded()
        {
            _random = new System.Random();
            CreateQuests();
            Run();
        }

        public void FillQuestData(CubeActor a,  CubeActor b) 
        {
            _questDatas.Add(new QuestData(a, b));
        }

        public string GetCurretQuestText()
        {
            if (_questIndex >= _sectionQuests.Count)
                return "";

            return _sectionQuests[_questIndex].QuestText;
        }

        public void CreateQuests()
        {
            int tempIndex = 0;
            int interval = 2;

            for (int i = 0; i < _questDatas.Count; ++i)
            {
                int randomIndex = _random.Next(1, 100);
                var sectionQuest = new SectionQuest();

                if (randomIndex % 2 == 0)
                {
                    sectionQuest.TargetCube = _questDatas[i].A;
                    sectionQuest.QuestText = _questDatas[i].A.GetMathResult().ToString();
                    sectionQuest.Result = _questDatas[i].A.GetMathResult();                    
                }else
                {
                    sectionQuest.TargetCube = _questDatas[i].B;
                    sectionQuest.QuestText = _questDatas[i].B.GetMathResult().ToString();
                    sectionQuest.Result = _questDatas[i].B.GetMathResult();
                }

                _sectionQuests.Add(sectionQuest);
            }
        }

        public void Run()
        {
            _questIndex = 0;

            _questDatas[_questIndex].A.EnableInteractive();
            _questDatas[_questIndex].B.EnableInteractive();
        }

        private void OnPlayerSelectedCube(CubeActor cube)
        {
            if (cube.IsInteractive == false) return;

            if(_sectionQuests[_questIndex].Result == cube.GetMathResult())
            {
                _gameEventsExec.OnPlayerSelectedTrueCube();
                cube.OnTrue();

                _questDatas[_questIndex].A.DisableInteractive();
                _questDatas[_questIndex].B.DisableInteractive();

                ++_questIndex;

                if(_questIndex < _questDatas.Count)
                {
                    _questDatas[_questIndex].A.EnableInteractive();
                    _questDatas[_questIndex].B.EnableInteractive();
                }
                else
                {
                    _gameEventsExec.OnLevelWin();
                }
            }
            else
            {
                _gameEventsExec.OnPlayerSelectedFalseCube();
                cube.OnFalse();
            }
        }

        private void OnDestroy()
        {
            _gameEvents.LevelLoaded -= OnLevelLoaded;
            _gameEvents.PlayerSelectedCube -= OnPlayerSelectedCube;
        }
    }
}