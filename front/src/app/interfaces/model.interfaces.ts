
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
    ADMIN = 'Admin',
    STAFF = 'Staff',
    CLIENT = 'Cliente'
}

type RoleKey = "ADMIN" | "STAFF" | "CLIENT"

export interface UserLogin {
    username: string,
    password: string
}

export interface ForgotPasswordRequest {
    email: string,
}

export interface ResetPasswordRequest {
    token: string,
    newPassword: string
}

export interface ChangePasswordRequest{
    currentPassword: string,
    newPassword: string
}

/// User
export interface UserRequest{
    id: number;
    name: string;
    active?: boolean;
}

export interface UserResponse{
    id: number;
    name: string;
    active: boolean;
}

export interface Liquidation{
    id: number;
    consortiumId: number;
    period: string; // Example: "2025-06"
    generateAt: Date;
    expirationDate: Date;
    amount: number;
    generateBy: number;
}

export interface LiquidationRequest{
    consortiumId: number;
    month: number;
    year: number;
    expirationDate: Date;
}

export interface ExpensesRequest{
    consortiumId: number;
    year: number;
    month?: number;
}

export interface FinancialRequest{
    consortiumId: number;
    format: string;
    year: number;
    month?: number;
}