import { calculatePenaltyModel } from './../_models/calculatePenaltyModel';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PenaltyService {

  baseurl = 'http://localhost:56367/api/';

  constructor(private http:HttpClient) { }

  getCountries(){
    return this.http.get(this.baseurl + 'countries');
  }

  calculatePenalty(calculatePenaltyModel: calculatePenaltyModel){
    return this.http.post(this.baseurl + 'penalty', calculatePenaltyModel);
  }



}
