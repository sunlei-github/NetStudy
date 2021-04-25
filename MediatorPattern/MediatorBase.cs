using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern
{
    /// <summary>
    /// 中介者负责 为房东出租房子 以及协调房东和租客的问题
    /// </summary>
    public abstract class MediatorBase
    {
        public landlordBase landlord { set; get; }
        public TenantBase Tenant { set; get; }

        public string Name { set; get; }

        public abstract void CoordinateHousePirce(double pirce);

        public virtual void IandlorDregisterHouse(double pirce)
        {
            landlord.RentOutHouse(pirce);
        }

        public virtual void TenantRentHouse(double pirce)
        {
            Tenant.RentingHouse(pirce);
        }
    }

    /// <summary>
    /// 自如租房
    /// </summary>
    public class ZiRu : MediatorBase
    {
        public override void CoordinateHousePirce(double pirce)
        {
            Tenant.PayHousePirce(pirce);
            landlord.CollectMoney(pirce);
        }

        public override void IandlorDregisterHouse(double pirce)
        {
            base.IandlorDregisterHouse(pirce);
        }

        public override void TenantRentHouse(double pirce)
        {
            base.TenantRentHouse(pirce);
        }
    }
}
