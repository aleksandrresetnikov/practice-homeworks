using System.Collections;

namespace Collections;

public class SmartStack<T> : IEnumerable<T>
{
    private T[] _items;
    private int _size;

    public int Count => _size;

    public int Capacity => _items.Length;

    public SmartStack()
    {
        _items = new T[4];
        _size = 0;
    }

    public SmartStack(int capacity)
    {
        if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), 
            "Емкость не может быть отрицательной.");
        
        _items = new T[capacity];
        _size = 0;
    }

    public SmartStack(IEnumerable<T> collection)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        _items = (collection is ICollection<T> coll)
            ? _items = new T[Math.Max(coll.Count, 4)]
            : _items = new T[4];
        
        foreach (var item in collection) Push(item);
    }

    public void Push(T item)
    {
        if (_size == _items.Length) UpSize(_items.Length == 0 ? 4 : _items.Length * 2);

        _items[_size] = item;
        _size++;
    }

    public void PushRange(IEnumerable<T> collection)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        if (collection is ICollection<T> coll)
        {
            int requiredCapacity = _size + coll.Count;
            
            if (requiredCapacity > _items.Length)
            {
                int newCapacity = _items.Length == 0 ? 4 : _items.Length;
                
                while (newCapacity < requiredCapacity) newCapacity *= 2;
                UpSize(newCapacity);
            }
        }

        foreach (var item in collection) Push(item);
    }

    public T Pop()
    {
        if (_size == 0) throw new InvalidOperationException("Стек пуст.");

        _size--;
        T topItem = _items[_size];
        
        _items[_size] = default; 

        return topItem;
    }

    public T Peek()
    {
        if (_size == 0) throw new InvalidOperationException("Стек пуст.");

        return _items[_size - 1];
    }

    public bool Contains(T item)
    {
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        
        for (int i = 0; i < _size; i++)
        {
            if (comparer.Equals(_items[i], item))
                return true;
        }
        
        return false;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс находится вне границ стека.");

            return _items[_size - 1 - index];
        }
        set
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс находится вне границ стека.");

            _items[_size - 1 - index] = value;
        }
    }

    private void UpSize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
            
        Array.Copy(_items, 0, newArray, 0, _size);
        _items = newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = _size - 1; i >= 0; i--)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}