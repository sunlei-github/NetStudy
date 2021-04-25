using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern
{
    /// <summary>
    /// 房东租房
    /// </summary>
    public abstract  class landlordBase
    {
        protected readonly MediatorBase mediator;

        public landlordBase(MediatorBase mediator)
        {
            this.mediator = mediator;
        }

        public string Name { set; get; }

       public abstract void RentOutHouse(double pirce);

        public virtual void CollectMoney(double pirce)
        {
            Console.WriteLine($"房东收到{mediator.Name}发来的房租{pirce}元");
        }
    }

    public class landlord: landlordBase
    {
        public landlord(MediatorBase mediator) : base(mediator)
        {
        }

        public override void RentOutHouse(double pirce)
        {
            Console.WriteLine($"{Name}房东以{pirce}元在{mediator.Name}出租房子!");
        }

    }

}
