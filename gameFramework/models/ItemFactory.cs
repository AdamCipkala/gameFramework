using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    public abstract class ItemFactory
    {
        public abstract AttackItem CreateAttackItem();
        public abstract DefenceItem CreateDefenceItem();
    }
}
