namespace Pr11_Blazor03.Persistence
{
    public static class DepartmentRepository
{
    private static List<string> departments = new List<string>()
    {
        "HR",
        "Marketing",
        "IT",
        "Finance",
        "Sales"
    };

    public static List<string> GetAll() => departments;
}

}
