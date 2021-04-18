using System;

namespace MemoPattern
{
    /// <summary>
    /// 备忘录模式
    /// 在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个对象。这样以后就可以将该对象恢复到原先保存的状态
    /// 备忘录模式 比较适用于功能比较复杂时，但需要维护或记录属性历史的类，或需要保存的属性只是众多属性中的一小部分时， 类似于缓存
    /// 但是如果备份的数据量比较大时也会消耗更多的资源
    /// 
    /// 备忘录模式的三个对象
    /// 需要备份的对象 
    /// 备忘录对象  里面具有需要备份对象的基本属性 之所以会有这个对象而不是直接使用需要备份的对象 是为了隔离数据 
    ///     当某一天备忘录需要存放其他数据信息时 这样不会影响到需要备份的类
    /// 备忘录管理的类 用来存放备忘录信息和读取备忘录信息 用来将备忘录的信息还原到当前正在使用的对象中
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            GameProgress gameProgress = new GameProgress();
            gameProgress.ATK = "200点攻击力";
            gameProgress.Health = "2000点血";
            gameProgress.Name = "剑圣";
            gameProgress.GameProgressName = "记录点1";
            gameProgress.Show();

            GameProgressMemoManager gameProgressMemoManager = new GameProgressMemoManager();
            //记录游戏进度
            gameProgressMemoManager.SaveGameProgressMemo(gameProgress.CreateGameProgressMemo());

            gameProgress.ATK = "100点攻击力";
            gameProgress.Health = "200点血";
            gameProgress.Show();

            //读取游戏进度
            gameProgress.GetGameProgressMemo(gameProgressMemoManager.ReadGameProgressMemo("记录点1"));
            //现在游戏的进度状态
            gameProgress.Show();


            Console.WriteLine("Hello World!");
        }
    }
}
