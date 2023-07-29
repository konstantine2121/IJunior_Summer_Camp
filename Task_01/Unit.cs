namespace Task_01
{
    internal class Unit :
        IFactionMember,
        IAttacker,
        IDamageable
    {
        private const double NeutralFactor = 1;
        private const double FriendlyFactor = 0.5;
        private const double EnemyFactor = 1.5;

        private const double BerserkDamageMultiplier = 2;
        private const double BerserkArmorMultiplier = 0.2;

        public Unit(
            string name,
            Factions faction,
            double health,
            double baseDamage,
            bool berserkMode,
            int baseArmor)
        {
            Faction = faction;
            Name = name;
            BaseDamage = baseDamage;
            BerserkMode = berserkMode;
            BaseArmor = baseArmor;
            Health = health;
        }

        public string Name { get; }

        public Factions Faction { get; }

        public double Health { get; private set; }

        public bool Alive => Health > 0;

        public double BaseDamage { get; }

        public double Damage => BerserkMode ?
            BaseDamage * BerserkDamageMultiplier :
            BaseDamage;

        public int BaseArmor { get; }

        public int Armor => BerserkMode ?
            (int)(BaseArmor * BerserkArmorMultiplier) :
            BaseArmor;


        public bool BerserkMode { get; private set; }

        private double ArmorMultiplier => 1 - Armor / 100.0;

        public void Attack(IDamageable target)
        {
            target.TakeDamage(this, Damage);
        }

        public void TakeDamage(IFactionMember attacker, double damage)
        {
            if (damage <= 0)
            {
                return;
            }

            var damageMultiplier = GetFactionDamageMultiplier(attacker.Faction, Faction);
            Health -= damage * ArmorMultiplier * damageMultiplier;
        }

        public static double GetFactionDamageMultiplier(Factions attacker, Factions damageable)
        {
            if (attacker == Factions.Neutral || damageable == Factions.Neutral)
            {
                return NeutralFactor;
            }

            if (attacker == damageable)
            {
                return FriendlyFactor;
            }

            return EnemyFactor;
        }
    }
}
