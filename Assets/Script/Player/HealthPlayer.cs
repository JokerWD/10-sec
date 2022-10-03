namespace TenSeconds
{
    public class HealthPlayer : Health
    {
        public bool PlayerDead { get; private set; }

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            if(IsDie)
                PlayerDead = true;
        }
        
       
       
    }
}
