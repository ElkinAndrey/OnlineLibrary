using OnlineLibraryAPI.Domain.Entities;

namespace OnlineLibraryAPI.Domain.Constants;
/// <summary>
///  Статический класс с константами ролей
/// </summary>
public static class RoleConstants
{
    /// <summary>
    ///  Роль авторизованного пользователя
    /// </summary>
    public static Role UserRole { get; } = new Role
    {
        Id = new Guid("73859e47-aa89-43ee-aada-f9794040cacf"),
        Name = "User"
    };
    /// <summary>
    ///  Роль менеджера
    /// </summary>
    public static Role ManagerRole { get; } = new Role
    {
        Id = new Guid("6bfd5453-fb0e-435c-bf54-638e994bdaf5"),
        Name = "Manager"
    };
    /// <summary>
    ///  Роль суперменеджера
    /// </summary>
    public static Role SuperManagerRole { get; } = new Role
    {
        Id = new Guid("5ff13486-f325-40a6-a41c-555259379dfb"),
        Name = "SuperManager"
    };
    /// <summary>
    ///  Роль админа
    /// </summary>
    public static Role AdminRole { get; } = new Role
    {
        Id = new Guid("4832250f-0b8e-4675-bba6-9badc22de7c9"),
        Name = "Admin"
    };
    /// <summary>
    ///  Роль суперадмина
    /// </summary>
    public static Role RootRole { get; } = new Role
    {
        Id = new Guid("af485b12-a0e4-4c45-89e8-4110f340160f"),
        Name = "Root"
    };
    /// <summary>
    ///  Список всех ролей
    /// </summary>
    public static Role[] Roles 
    {
        get
        {
            return new Role[]
            {
                UserRole,
                ManagerRole,
                SuperManagerRole,
                AdminRole,
                RootRole
            };
        }
    }
}
