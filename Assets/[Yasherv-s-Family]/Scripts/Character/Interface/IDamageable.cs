namespace Character
{
    public enum CharacterType
    {
        Player,
        Enemy
    }
    public interface IDamageable
    {
        CharacterType GetCharacterType { get; }
        void TakeDamage(int damage);
    }
}