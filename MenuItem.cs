public class MenuItem<T>
{
    public string Text { get; }
    public T Value { get; }

    public MenuItem(string text, T value)
    {
        Text = text;
        Value = value;
    }
}