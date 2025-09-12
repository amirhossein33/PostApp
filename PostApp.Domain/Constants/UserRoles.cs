namespace PostApp.Domain.Constants;

public static class UserRoles
{
    public const string Manager = "Manager";
    public const string Driver = "Driver";

    public static readonly string[] AllRoles = { Manager, Driver };
}
