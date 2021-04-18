using System;
using System.Collections.Generic;
using System.Text;

namespace MemoPattern
{
    /// <summary>
    /// 游戏进度的备忘录
    /// </summary>
    public class GameProgressMemo : GameProgressBase
    {
        private readonly GameProgressBase _gameProgress;

        public GameProgressMemo(GameProgressBase gameProgress)
        {
           _gameProgress = gameProgress;
            InitGameProgressMemo();
        }

        private void InitGameProgressMemo()
        {
            this.ATK = _gameProgress.ATK;
            this.Health = _gameProgress.Health;
            this.Name = _gameProgress.Name;
            this.GameProgressName = _gameProgress.GameProgressName;
        }
    }
}
