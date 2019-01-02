import { Component, OnInit } from '@angular/core';
import { ScheduleService } from 'src/app/services/schedule.service';
import { Patient } from 'src/app/shared/patient';
import * as moment from 'moment';
import { Moment } from 'moment';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {

 today: string;
 initialDate: Moment [] = [];

  constructor(private _scheduleService: ScheduleService) {
    this.today = moment().format('MMM Do YY');
    this.fillDates();
  }

  fillDates() {
    let date = moment(moment().format('YYYY-MM-DD 08:00'));
    for (let i = 0; i < 19; i++) {
      date = moment(date).add(30, 'minutes');
      this.initialDate.push(moment(date));
    }
  }

  getCitesByHour(hour: Moment) {
    return this._scheduleService.getCiteByDate(hour);
  }
  ngOnInit() {
  }

}
