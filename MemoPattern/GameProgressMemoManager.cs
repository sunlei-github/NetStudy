using System;
using System.Collections.Generic;
using System.Text;

namespace MemoPattern
{
    /// <summary>
    /// 游戏进度的管理者
    /// </summary>
    public class GameProgressMemoManager
    {
        private Dictionary<string, GameProgressMemo> gameProgressMemos = new Dictionary<string, GameProgressMemo>();

        /// <summary>
        /// 根据游戏进度名称记录游戏进度
        /// </summary>
        /// <param name="gameProgress"></param>
        public void SaveGameProgressMemo(GameProgressMemo gameProgress)
        {
            if (!gameProgressMemos.ContainsKey(gameProgress.GameProgressName))
            {
                gameProgressMemos.Add(gameProgress.GameProgressName, gameProgress);
            }
            else
            {
                //覆盖游戏进度
                gameProgressMemos[gameProgress.GameProgressName] = gameProgress;
            }
        }

        /// <summary>
        /// 根据游戏读取游戏名称读取游戏进度
        /// </summary>
        public GameProgressMemo ReadGameProgressMemo(string gameName)
        {
            if (gameProgressMemos.ContainsKey(gameName))
            {
                return gameProgressMemos[gameName];
            }

            return null;
        }

    }
}
