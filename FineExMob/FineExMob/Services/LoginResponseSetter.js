export function loginResponseSetter(response) {
    const {
        Email:email,
        FirstName: firstName,
        LastName: lastName,
        Id: id,
        IsActive: isActive,
        RoleId: roleId,
        Companies: companies
    } = response;
    return {
        email,
        firstName,
        lastName,
        id,
        isActive,
        roleId,
        companies
    }
}