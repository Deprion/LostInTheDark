using System;

public class SimpleEvent<T>
{
    private event Action<T> listeners;

    private T storedValue;

    public void AddListener(Action<T> listener, bool notifySender = false)
    {
        listeners += listener;

        if (notifySender && storedValue != null) listener?.Invoke(storedValue);
    }

    public void RemoveListener(Action<T> listener)
    {
        listeners -= listener;
    }

    public void Invoke(T value)
    {
        storedValue = value;

        listeners?.Invoke(value);
    }
}

public class SimpleEvent<T, Y>
{
    private event Action<T, Y> listeners;

    private T TValue;
    private Y YValue;

    public void AddListener(Action<T, Y> listener, bool notifySender = false)
    {
        listeners += listener;

        if (notifySender && TValue != null) listener?.Invoke(TValue, YValue);
    }

    public void RemoveListener(Action<T, Y> listener)
    {
        listeners -= listener;
    }

    public void Invoke(T Tvalue, Y Yvalue)
    {
        TValue = Tvalue;
        YValue = Yvalue;

        listeners?.Invoke(TValue, YValue);
    }
}
