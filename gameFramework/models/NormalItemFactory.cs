using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    public class NormalItemFactory : ItemFactory
    {
        public override AttackItem CreateAttackItem()
        {
            return new AttackItem();
        }

        public override DefenceItem CreateDefenceItem()
        {
            return new DefenceItem();
        }
    }
}
