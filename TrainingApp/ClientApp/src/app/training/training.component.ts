import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';
import { Training } from './training';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.scss']
})
export class TrainingComponent implements OnInit {
  public trainings: Training[] = [];
  constructor(protected httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
    this.httpClient
      .get<Training[]>(baseUrl + 'api/Training')
      .subscribe(trainings => (this.trainings = trainings));
  }

  ngOnInit() {
    
  }
}
