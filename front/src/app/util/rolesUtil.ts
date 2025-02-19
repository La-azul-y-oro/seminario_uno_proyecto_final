export const hasValidRoles = (userData : any, roles : string[]) => { 
    return roles.includes(userData?.role);
}