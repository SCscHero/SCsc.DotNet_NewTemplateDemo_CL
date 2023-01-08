using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.FactoryCorrelation.Interface
{
    public interface IManeuverability
    {
        void Training<T>(T unit) ;

        void AttackFormation();

        void DefenseFormation();
    }
}
