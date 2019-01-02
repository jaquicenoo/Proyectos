import { Injectable } from '@angular/core';
import { Cites } from '../shared/cites';
import { Moment } from 'moment';
import * as moment from 'moment' ;

@Injectable()
export class ScheduleService {

    private cites: Cites[] = [
        {
            date: moment('2018-12-16 8:00', 'YYYY-MM-DD HH:mm'),
            patient : {
                name: 'Eduardo Felipe Solis Hernandez',
                procedure: 'Cita primera vez',
                identification: 43125124,
                eps: 'Compensar',
                edad: 45,
              }
        },
        {
            date: moment('2018-12-16 11:20', 'YYYY-MM-DD HH:mm'),
            patient : {
                name: 'Jhon alexander quiceno orozco',
                procedure: 'Control',
                identification: 43125124,
                eps: 'AlianSalud',
                edad: 24,
              }
        },
        {
            date: moment('2018-12-17 8:00', 'YYYY-MM-DD HH:mm'),
            patient : {
                name: 'Diego fernando zapata',
                procedure: 'Cita primera vez',
                identification: 43125124,
                eps: 'Compensar',
                edad: 28,
              }
        }

    ];
      getCiteByDate(date: Moment) {
          const dateCites: Cites[] = [];
          const format = 'YYYY-MM-DD HH:';
          this.cites.forEach( cite => {
              if (cite.date.format(format) === date.format(format)) {
                  dateCites.push(cite);
              }
          });
          return dateCites;
      }
}

