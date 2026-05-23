using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleArena
{
    public class Monster
    {
        // Properties: What attributes would a monster need? 
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int BaseAttack { get; set; }
        public bool IsDefending { get; set; }
    }
}
