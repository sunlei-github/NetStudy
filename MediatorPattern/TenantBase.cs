using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern
{
    /// <summary>
    /// 租客
    /// </summary>
    public abstract class TenantBase
    {
        protected readonly MediatorBase mediator;

        public TenantBase(MediatorBase mediator)
        {
            this.mediator = mediator;
        }

        public string Name { set; get; }

        /// <summary>
        /// 租房
        /// </summary>
        /// <param name="pirce"></param>
        public abstract void RentingHouse(double pirce);

        /// <summary>
        /// 付房租
        /// </summary>
        /// <param name="pirce"></param>
        public virtual void PayHousePirce(double pirce)
        {
            Console.WriteLine($"{Name}向{mediator.Name}交房租{pirce}元");
        }
    }

    public class Tenant : TenantBase
    {
        public Tenant(MediatorBase mediator) : base(mediator)
        {
        }

        public override void RentingHouse(double pirce)
        {
            Console.WriteLine($"{Name}租户以{pirce}元在{mediator.Name}租到房子");
        }

    }
}
