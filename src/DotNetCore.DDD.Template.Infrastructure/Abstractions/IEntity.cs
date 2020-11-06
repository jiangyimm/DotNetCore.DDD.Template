namespace DotNetCore.DDD.Template.Infrastructure.Abstractions
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
}