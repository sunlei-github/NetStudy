using System;
using System.Collections.Generic;
using System.Text;

namespace CompsitePattern
{
    /// <summary>
    /// 组织机构的基类 
    /// </summary>
    public abstract class OrganizationBase
    {
        private string _name;

        protected List<OrganizationBase> Organizations = new List<OrganizationBase>();

        public OrganizationBase(string name)
        {
            _name = name;
        }

        /// <summary>
        /// 增加子节点
        /// </summary>
        /// <param name="organization"></param>
        public abstract void AddChildren(OrganizationBase organization);

        /// <summary>
        /// 删除子节点
        /// </summary>
        /// <param name="organization"></param>
        public abstract void RemoveChildren(OrganizationBase organization);

        public virtual void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + _name);
        }
    }

    /// <summary>
    /// 总部
    /// </summary>
    public class HeadOrganization : OrganizationBase
    {
        public HeadOrganization(string name) : base(name)
        {
        }

        public override void AddChildren(OrganizationBase organization)
        {
            this.Organizations.Add(organization);
        }

        public override void RemoveChildren(OrganizationBase organization)
        {
            this.Organizations.Remove(organization);
        }


        public override void Display(int depth)
        {
            base.Display(depth);
            ++depth;

            foreach (var organization in base.Organizations)
            {
                organization.Display(depth);
            }
        }
    }

    /// <summary>
    /// 总部分部
    /// </summary>
    public class HeadBranchOrganization : OrganizationBase
    {
        public HeadBranchOrganization(string name) : base(name)
        {
        }

        public override void AddChildren(OrganizationBase organization)
        {
            this.Organizations.Add(organization);
        }

        public override void Display(int depth)
        {
            base.Display(depth);
            ++depth;

            foreach (var organization in base.Organizations)
            {
                organization.Display(depth);
            }
        }

        public override void RemoveChildren(OrganizationBase organization)
        {
            this.Organizations.Remove(organization);
        }
    }

    /// <summary>
    /// 总部分部的城市分部
    /// </summary>
    public class HeadBranchCityOrganization : OrganizationBase
    {
        public HeadBranchCityOrganization(string name) : base(name)
        {
        }

        public override void AddChildren(OrganizationBase organization)
        {
            this.Organizations.Add(organization);
        }

        public override void Display(int depth)
        {
            base.Display(depth);
        }

        public override void RemoveChildren(OrganizationBase organization)
        {
            this.Organizations.Remove(organization);
        }
    }
}
