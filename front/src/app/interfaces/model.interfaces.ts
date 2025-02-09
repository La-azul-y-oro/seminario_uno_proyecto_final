//Concept
export interface ConceptRequest{
    id: number;
    name: string;
    active?: boolean;
}

export interface ConceptResponse{
    id: number;
    name: string;
    active: boolean;
}

export enum DocumentType {
    DNI = 'DNI',
    CUIL = 'CUIL',
    CUIT = 'CUIT'
}

//Consortium
export interface ConsortiumRequest{
    id: number;
    name: string;
    address: string;
    active?: boolean;
}

export interface ConsortiumResponse{
    id: number;
    name: string;
    address: string;
    active: boolean;
}

//Supplier
export interface SupplierRequest{
    id: number;
    cuit: number;
    name: string;
    phone: string;
    email: string;
    active?: boolean;
}

export interface SupplierResponse{
    id: number;
    cuit: number;
    name: string;
    phone: string;
    email: string;
    active?: boolean;
}


export enum Role {
    ROLE_ADMIN = 'admin',
    ROLE_USER = 'usuario'
}

type RoleKey = "ROLE_ADMIN" | "ROLE_USER" 

export interface EmployeeLogin {
    email:string,
    password:string
}