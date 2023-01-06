﻿namespace BikeSparesInventorySystem.Data.Repositories;

internal class Repository<TSource> : RepositoryIO<TSource>, IRepository<TSource> where TSource : IModel
{
    public Repository(FileProvider<TSource> fileProvider) : base(fileProvider)
    {
    }

    public virtual int Count => _sourceData.Count;

    public virtual void Add(TSource item)
    {
        _sourceData.Add(item);
    }

    public virtual void Clear()
    {
        _sourceData.Clear();
    }

    public virtual bool Contains(TSource item)
    {
        return _sourceData.Contains(item);
    }

    public virtual bool Contains<TKey>(Func<TSource, TKey> keySelector, TKey byValue)
    {
        return Get(keySelector, byValue) is not null;
    }

    public virtual TSource Get<TKey>(Func<TSource, TKey> keySelector, TKey byValue)
    {
        return _sourceData.FirstOrDefault(a => keySelector.Invoke(a).Equals(byValue));
    }

    public virtual ICollection<TSource> GetAll()
    {
        return _sourceData;
    }

    public virtual ICollection<TSource> GetAllSorted<TKey>(Func<TSource, TKey> keySelector, Enums.SortDirection direction)
    {
        return direction switch
        {
            Enums.SortDirection.Ascending => _sourceData.OrderBy(keySelector).ToList(),
            Enums.SortDirection.Descending => _sourceData.OrderByDescending(keySelector).ToList(),
            _ => throw new Exception("Invalid sort direction!"),
        };
    }

    public virtual bool Remove(TSource item)
    {
        return _sourceData.Remove(item);
    }
}
