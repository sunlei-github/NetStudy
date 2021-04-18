using System;
using System.Collections.Generic;
using System.Text;

namespace MemoPattern
{
    /// <summary>
    /// 游戏进度的基本信息
    /// </summary>
    public abstract class GameProgressBase
    {
        /// <summary>
        /// 游戏名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 血量
        /// </summary>
        public string Health { set; get; }

        /// <summary>
        /// 攻击力
        /// </summary>
        public string ATK { set; get; }

        /// <summary>
        /// 游戏进度名称
        /// </summary>
        public string GameProgressName { set; get; }
    }

    public class GameProgress : GameProgressBase
    {

        /// <summary>
        /// 创建一个游戏进度 相当于备忘录
        /// </summary>
        public GameProgressMemo CreateGameProgressMemo()
        {
            return new GameProgressMemo(this);
        }

        /// <summary>
        /// 根据进度初始化游戏的进度
        /// </summary>
        public void GetGameProgressMemo(GameProgressMemo gameProgressMemo)
        {
            this.ATK = gameProgressMemo.ATK;
            this.GameProgressName = gameProgressMemo.GameProgressName;
            this.Health = gameProgressMemo.Health;
            this.Name = gameProgressMemo.Name;
        }

        public void Show()
        {
            Console.WriteLine($"游戏人物现在的状态,游戏名{this.Name},血量状态{this.Health},攻击力{this.ATK}");
        }
    }
}
