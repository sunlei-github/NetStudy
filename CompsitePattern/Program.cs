using System;

namespace CompsitePattern
{
    /// <summary>
    /// 组合模式  
    /// 将对象组合成树形结构以表示 部分-整体的层次结构 组合模式使得用户对单个对象和组合对象的使用具有一致性
    /// 
    /// 对于组合模式的树形结构  父类中的Add Remove方法是为了控制自己本身拥有的子节点
    /// 
    /// 但是对于枝节点 和叶节点来说  叶节点本身是不需要Add Remove方法的 如果枝节点 和叶节点所继承的父类拥有Add Remove方法 
    /// 那么这就是一个透明模式 对于外界来说更加方便不用区分枝和叶
    /// 但是如果枝节点 和叶节点所继承的父类没有Add Remove方法  而枝节点中却实现了Add Remove方法 那么这就是安全模式，客户端需要
    /// 知道具体哪个是枝节点哪个叶节点 反而使的客户端调用时比较麻烦
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            OrganizationBase rootOrganization = new HeadOrganization("总部基地");

            //总部的南北总分部
            OrganizationBase southOrganization = new HeadOrganization("南方分部");
            OrganizationBase northOrganization = new HeadOrganization("北方分部");
            rootOrganization.AddChildren(southOrganization);
            rootOrganization.AddChildren(northOrganization);

            //南方分部的子部门
            OrganizationBase shangHaiOrganization = new HeadOrganization("南方上海分部");
            OrganizationBase wuHanOrganization = new HeadOrganization("南方武汉分部");
            OrganizationBase guangZhouOrganization = new HeadOrganization("南方广州分部");
            southOrganization.AddChildren(shangHaiOrganization);
            southOrganization.AddChildren(wuHanOrganization);
            southOrganization.AddChildren(guangZhouOrganization);

            //北方方分部的子部门
            OrganizationBase shanxiOrganization = new HeadOrganization("北方山西分部");
            OrganizationBase tianJinOrganization = new HeadOrganization("北方天津分部");
            northOrganization.AddChildren(shanxiOrganization);
            northOrganization.AddChildren(tianJinOrganization);

            rootOrganization.Display(1);


            Console.WriteLine("Hello World!");
        }
    }
}
