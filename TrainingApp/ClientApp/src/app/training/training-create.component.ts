import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Training } from './training';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-training-create',
  templateUrl: './training-create.component.html',
  styleUrls: ['./training-create.component.scss']
})
export class TrainingCreateComponent implements OnInit {
  public name = new FormControl('');
  public trainingStartDate = new FormControl();
  public trainingEndDate = new FormControl();
  public minDate = new Date();
  protected url = '';
  error: any = { isError: false, errorMessage: '' };
    isValidDate: any;
  constructor(protected httpClient: HttpClient, private datePipe: DatePipe,private router: Router, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'api/training'
  }

  ngOnInit() {
    
  }

  create() {
    const training: Training = {
      name: this.name.value,
      trainingStartDate: this.trainingStartDate.value,
      trainingEndDate: this.trainingEndDate.value
    };

    const trainingStartDateStr = this.datePipe.transform(this.trainingStartDate.value, "dd-MM-yyyy");
    const trainingEndDateStr = this.datePipe.transform(this.trainingEndDate.value, "dd-MM-yyyy");

    this.isValidDate = this.validateDates(trainingStartDateStr, trainingEndDateStr);
    if (this.isValidDate) {
      this.httpClient
        .post<Training>(`${this.url}`, training)
        .subscribe(
          () => this.router.navigate(['/trainings']),
          error => alert('Error adding training: ' + JSON.stringify(error))
        );
    }
    
  }

  validateDates(sDate: string, eDate: string) {
    this.isValidDate = true;
    if ((sDate == null || eDate == null)) {
      this.error = { isError: true, errorMessage: 'Start date and end date are required.' };
      this.isValidDate = false;
    }

    if ((sDate != null && eDate != null) && (eDate) < (sDate)) {
      this.error = { isError: true, errorMessage: 'End date should be grater then start date.' };
      this.isValidDate = false;
    }
    return this.isValidDate;
  }
}
