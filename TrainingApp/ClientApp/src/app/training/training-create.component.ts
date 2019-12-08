import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Training } from './training';
import * as moment from 'moment';

@Component({
  selector: 'app-training-create',
  templateUrl: './training-create.component.html',
  styleUrls: ['./training-create.component.scss']
})
export class TrainingCreateComponent implements OnInit {
  public name = new FormControl('');
  public price = new FormControl('');
  protected url = 'http://localhost:5000/api/trainings';
  constructor(protected httpClient: HttpClient, private router: Router) {}

  ngOnInit() {}

  create() {
    const training: Training = {
      name: this.name.value,
      price: this.price.value
    };
    this.httpClient
      .post<Training>(`${this.url}`, training)
      .subscribe(
        () => this.router.navigate(['/training']),
        error => alert('Error adding training: ' + JSON.stringify(error))
      );
  }
}
