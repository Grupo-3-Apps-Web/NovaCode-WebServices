namespace NovaCode_Web_Services.Profile.Domain.Model.Aggregate;

public class Profile
{
    public int Id { get; }
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public string Birthday { get; private set; } = string.Empty;
    public string Dni { get; private set; } = string.Empty;
    public string ImageProfile { get; private set; } = string.Empty;

    public Profile() {}

    public Profile(string fullName, string email, string phone, string address, string birthday, string dni, string imageProfile)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
        Address = address;
        Birthday = birthday;
        Dni = dni;
        ImageProfile = imageProfile;
    }

    public void UpdateUser(string fullName, string email, string phone, string address, string birthday, string dni, string imageProfile)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
        Address = address;
        Birthday = birthday;
        Dni = dni;
        ImageProfile = imageProfile;
    }
}