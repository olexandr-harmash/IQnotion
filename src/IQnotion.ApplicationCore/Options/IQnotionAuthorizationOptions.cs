namespace IQnotion.ApplicationCore.Options;

public class IQnotionAuthorizationOptions
{
    private double _expire = 30;
    private string _validIssuer = null!;
    private string _validAudience = null!;

    public double Expire
    {
        get => _expire;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Expire), "Expire must be a positive number.");
            _expire = value;
        }
    }

    public string ValidIssuer
    {
        get => _validIssuer;
        set => _validIssuer = !string.IsNullOrEmpty(value)
            ? value
            : throw new ArgumentException("ValidIssuer cannot be null or empty.", nameof(ValidIssuer));
    }

    public string ValidAudience
    {
        get => _validAudience;
        set => _validAudience = !string.IsNullOrEmpty(value)
            ? value
            : throw new ArgumentException("ValidAudience cannot be null or empty.", nameof(ValidAudience));
    }
}
