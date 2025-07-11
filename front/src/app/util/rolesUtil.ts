export const hasValidRoles = (userData : any, roles : string[]) => { 
    const roleAttr = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
    return roles.includes(userData?.[roleAttr]);
}