using System;
using System.Collections.Generic;
using UnityEngine;

namespace TGS.Domain.Battle.System
{
    public interface IBattleMainLoop
    {
        IList<IUpdatable> List { get; }

        void Register(IUpdatable module);
        void Unregister(IUpdatable module);
    }

    public interface IUpdatable
    {
        void Initialize();
        void UpdateByFrame();
    }

    public class BattleMainLoop : MonoBehaviour, IBattleMainLoop
    {
        private static BattleMainLoop instance;
        public static BattleMainLoop Instance()
        { 
            if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "BattleMainLoop";
                    instance = go.AddComponent<BattleMainLoop>();
                }
                return instance;
        }
        private BattleMainLoop(){}
        
        private IList<IUpdatable> list;
        public IList<IUpdatable> List { get; private set; }

        public void Register(IUpdatable module)
        {
            if (!this.list.Contains(module))
            {
                this.list.Add(module);
            }
        }

        public void Unregister(IUpdatable module)
        {
            if (this.list.Contains(module))
            {
                this.list.Remove(module);
            }
        }

        private void Start()
        {
            foreach(IUpdatable system in this.list)
            {
                system.Initialize();
            }
        }

        private void Update()
        {
            foreach(IUpdatable system in this.list)
            {
                system.UpdateByFrame();
            }
        }
    }
}