namespace DotNetCore.DDD.Template.Infrastructure.Domain
{
    /// <summary>
    /// 实体
    /// </summary>
    public interface IEntity
    {
        object[] GetKeys();
    }

    /// <summary>
    ///  实体 带主键
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; }
    }

    public abstract class Entity : IEntity
    {
        public abstract object[] GetKeys();
    }

    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        public virtual TKey Id { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { Id };
        }
    }
}