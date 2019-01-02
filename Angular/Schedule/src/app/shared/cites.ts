import { Patient } from './patient';
import { Moment } from 'moment';
export interface Cites {
    date: Moment;
    patient: Patient;
}
