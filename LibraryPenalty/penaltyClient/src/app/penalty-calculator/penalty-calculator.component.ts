import { calculatePenaltyModel } from './../_models/calculatePenaltyModel';
import { Penalty } from './../_models/penaltyModel';
import { PenaltyService } from './../_services/penalty.service';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CountryModel } from '../_models/countryModel';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-penalty-calculator',
  templateUrl: './penalty-calculator.component.html',
  styleUrls: ['./penalty-calculator.component.css']
})
export class PenaltyCalculatorComponent implements OnInit {

  constructor(private penaltyService: PenaltyService, private toastr: ToastrService) { }

  Countries: CountryModel[];
  calculateModel: calculatePenaltyModel = { checkoutDate: null, returnDate: null, countryId: 0 };
  penaltyModel: Penalty = null;

  ngOnInit(): void {
    this.calculateModel.checkoutDate = null;
    this.calculateModel.returnDate = null;
    this.penaltyService.getCountries().subscribe((response: CountryModel[]) => {
      this.Countries = response;
    }, error => {
      this.toastr.error(error.error);
      console.log(error);
    });
  }

  calculatePenalty() {

    if (this.validate()) {
      this.penaltyService.calculatePenalty(this.calculateModel).subscribe((response: Penalty) => {
        if (response != null) {
          this.penaltyModel = response;
        }
        else {
          this.toastr.error("An error occured while processing the request!!");
        }
      }, error => {
        this.toastr.error(error.error);
        console.log(error);
      });
    }
    else {
      this.penaltyModel = null;
    }

  }

  validate(): boolean {
    var result: boolean = true;
    if (this.calculateModel.checkoutDate == null || this.calculateModel.returnDate == null) {
      this.toastr.error("Select the Checkout and Return Date", "Error");
      result = false;
    }
    else if (this.calculateModel.checkoutDate > this.calculateModel.returnDate) {
      this.toastr.error("Return Date cannot be less than Checkout Date", "Error");
      result = false;
    }
    else if (this.calculateModel.countryId == 0) {
      this.toastr.error("Select the Country", "Error");
      result = false;
    }
   
     
    return result;
  }
}
