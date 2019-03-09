import { User } from './user';

export interface Locataire {
    id: number;
    user: User;
    LocataireStatut: string;
    Reference: string;
}
